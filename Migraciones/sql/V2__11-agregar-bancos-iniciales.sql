INSERT INTO bancos.banco (codigo,nombre,pais, activo)
VALUES ('BR','Banco Rural','GT', true) ;

INSERT INTO bancos.banco (codigo,nombre,pais, activo)
VALUES ('BI','Banco de la Industria','GT', true) ;

INSERT INTO bancos.operacion (nombre)
    VALUES 
        ('PAGO_TARJETA_CREDITO'),
        ('PAGO_PRESTAMO'),
        ('CONSULTA_SALDOS'),
        ('PAGO_SERVICIOS');
