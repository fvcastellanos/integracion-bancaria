using System;
using System.Collections.Generic;
using IntegracionBancaria.Domain;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Service
{
    public class ServicioMock
    {
        public static IList<Cuenta> ConsultarSaldos(Perfil perfil, string codigoBanco)
        {
            var lista = new List<Cuenta>();
            lista.Add(new Cuenta { 
                NombreCuenta = perfil.Nombres + " " + perfil.Apellidos, 
                Moneda = "GTQ",
                SaldoDisponible = 20000,
                SaldoEnReserva = 15000,
                SaldoFlotante = 0,
                SaldoTotal = 35000
            });

            return lista;
        }

        public static IList<Movimiento> ObtenerMovimientos()
        {
            var lista = new List<Movimiento>();

            lista.Add(new Movimiento() {
                Fecha = DateTime.Now,
                Numero = "X234",
                Moneda = "GTQ",
                Debito = 1340.33,
                Credito = 0
            });   

            lista.Add(new Movimiento() {
                Fecha = DateTime.Now,
                Numero = "X235",
                Moneda = "GTQ",
                Debito = 0,
                Credito = 10000
            });   

            return lista;
        }

    }
}