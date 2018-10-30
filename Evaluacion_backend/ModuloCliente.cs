using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using System.Linq;
using Evaluacion_backend.Models;
using Nancy.ModelBinding;
using Nancy.Validation;
using FluentValidation.Results;

namespace Evaluacion_backend
{
    public class ModuloCliente: NancyModule
    {
        private static IDictionary<Guid,Cliente> clientes = new SortedDictionary<Guid, Cliente>();

        public ModuloCliente() : base("/clientes")
        {
            //devuelve todos los clientes
            Get("/list", args => {
                return clientes.Values;
            });

            //devuelve el cliente asociado con id si lo hubiera
            Get("/{id}", args => {
                Cliente cl;
                try {
                    clientes.TryGetValue(args.Id, out cl);
                }
                catch(Exception e) {
                    return e.Message;
                }
               
                if (cl != null)
                {
                    return cl;
                }
                else
                {
                    return "Error, no existe un cliente con Id "+args.Id+" .";
                }
            });

            //agrega un cliente
            Post("/add/{id}", args => {
                var model = this.Bind<Cliente>();
                var result = this.Validate(model);

                if (result.IsValid)
                {
                    bool resu=false;
                    try
                    {
                        resu = clientes.ContainsKey(args.Id);

                    }catch(Exception e)
                    {
                        return e.Message;
                    }

                    if (!resu)
                    {
                        clientes.Add(args.Id, model);
                        return model;
                    }
                    else
                    {
                        clientes.TryGetValue(args.Id, out Cliente cl);
                        return "Error, ya existe un cliente con Id " + args.Id +".";
                    }
                }
                else
                {
                    var resus = result.Errors.Values;
                    string cartel="Error(es): \n";
                    int largo = resus.Count;
                    for(int i=0; i < largo; i++)
                    {
                        cartel = cartel + " " +resus.ElementAt(i).ElementAt(0)+"\n ";
                    }
                    return cartel;
                }
                
            });

            //actualiza el cliente id
            Put("update/{id}", args => {
                var model = this.Bind<Cliente>();
                var result = this.Validate(model);

                if (result.IsValid)
                {
                    bool resu = false;
                    try
                    {
                        resu = clientes.ContainsKey(args.Id);
                    }
                    catch(Exception e)
                    {
                        return e.Message;
                    }

                    if (resu)
                    {
                        clientes.Remove(args.Id);
                        clientes.Add(args.Id, model);
                        return model;
                    }
                    else
                    {
                        return "Error, no existe un cliente con Id " + args.Id + " .";
                    }
                }
                else
                {
                    var resus = result.Errors.Values;
                    string cartel = "Error(es): \n";
                    int largo = resus.Count;
                    for (int i = 0; i < largo; i++)
                    {
                        cartel = cartel + " " + resus.ElementAt(i).ElementAt(0) + " \n";
                    }
                    return cartel;
             
                }
                
            });


            Delete("delete/{id}", args =>
            {
                Cliente cl;
                try
                {
                    clientes.TryGetValue(args.Id, out cl);
                }
                catch(Exception e)
                {
                    return e.Message;
                }

                var res = clientes.Remove(args.Id);
                if (res)
                {
                    return "Cliente " + args.Id + " eliminado. \n";
                }
                else
                {
                    return "Error, no existe cliente de Id " + args.Id + ".";
                }
            });
        }
    }
}
