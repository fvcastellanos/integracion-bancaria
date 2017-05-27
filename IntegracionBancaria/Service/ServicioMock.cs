using System;
using System.Collections.Generic;
using IntegracionBancaria.Domain;
using IntegracionBancaria.Model.Domain;
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

        public static IList<Prestamo> ConsultarSaldoPrestamos(Perfil perfil, string codigoBanco)
        {
            var lista = new List<Prestamo>();
            lista.Add(new Prestamo { 
                NumeroPrestamo = "PRES" + GenerarNumeroCuentasOTarjetasRandom(8),
                NombreCuenta = perfil.Nombres + " " + perfil.Apellidos, 
                Moneda = "GTQ",
                SaldoDisponible = float.Parse(GenerarNumeroCuentasOTarjetasRandom(4)),
                SaldoEnReserva = float.Parse(GenerarNumeroCuentasOTarjetasRandom(3)),
                SaldoFlotante = float.Parse(GenerarNumeroCuentasOTarjetasRandom(2)),
                SaldoTotal = float.Parse(GenerarNumeroCuentasOTarjetasRandom(4)),
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