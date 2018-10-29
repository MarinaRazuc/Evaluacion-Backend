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
                clientes.TryGetValue(args.Id, out cl);
                if (cl != null)
                {
                    return cl;
                }
                else
                {
                    return "Error, no existen clientes con Id "+args.Id+" .";
                }
            });

            //agrega un cliente
            Post("/add/{id}", args => {
                var model = this.Bind<Cliente>();
                var result = this.Validate(model);

                if (result.IsValid)
                {
                    if (!clientes.ContainsKey(args.Id))
                    {
                        clientes.Add(args.Id, model);
                        return model;
                    }
                    else
                    {
                        clientes.TryGetValue(args.Id, out Cliente cl);
                        return "Error, ya existe un cliente con Id " + args.Id + " . \n \n" + cl.ToString();
                    }
                }
                else
                {
                    var resus = result.Errors.Values;
                    return resus;
                }
                
            });

            //actualiza el cliente id
            Put("update/{id}", args => {
                var model = this.Bind<Cliente>();
                var result = this.Validate(model);

                if (result.IsValid)
                {
                    if (clientes.ContainsKey(args.Id))
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
                    
                    return result.Errors;
                }
                
            });


            Delete("delete/{id}", args =>
            {
                Cliente cl;
                clientes.TryGetValue(args.Id, out cl);
                var res = clientes.Remove(args.Id);
                if (res)
                {
                    return "Cliente " + args.Id + " eliminado. \n"+cl;
                }
                else
                {
                    return "Error, no existe cliente de Id " + args.Id + ".";
                }
            });
        }
    }
}
