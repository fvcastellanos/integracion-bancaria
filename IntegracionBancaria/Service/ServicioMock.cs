using System;
using System.Collections.Generic;
using IntegracionBancaria.Domain;
using IntegracionBancaria.Model.Domain.Mock;

namespace IntegracionBancaria.Service
{
    public class ServicioMock
    {
        public static IList<Cuenta> ConsultarSaldos(Perfil perfil, string codigoBanco)
        {
            var lista = new List<Cuenta>();
            lista.Add(new Cuenta { 
                NumeroCuenta = GenerarNumeroCuentasOTarjetasRandom(8),
                NombreCuenta = perfil.Nombres + " " + perfil.Apellidos, 
                Moneda = "GTQ",
                SaldoDisponible = 20000,
                SaldoEnReserva = 15000,
                SaldoFlotante = 0,
                SaldoTotal = 35000
            });

            return lista;
        }

        public static IList<Tarjeta> ConsultarSaldoTarjetas(Perfil perfil, string codigoBanco)
        {
            var lista = new List<Tarjeta>();
            lista.Add(new Tarjeta { 
                NumeroTarjeta = GenerarNumeroCuentasOTarjetasRandom(16),
                NombreCuenta = perfil.Nombres + " " + perfil.Apellidos, 
                Moneda = "GTQ",
                SaldoDisponible = 20000,
                SaldoEnReserva = 15000,
                SaldoFlotante = 0,
                SaldoTotal = 35000
            });

            return lista;
        }

        private static string GenerarNumeroCuentasOTarjetasRandom(long length)
        {
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = char.Parse(random.Next(0, 9).ToString());
            }
            return new String(stringChars);
        }
    }
}