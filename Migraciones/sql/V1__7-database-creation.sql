
SET search_path TO pg_catalog,public,bancos;
-- ddl-end --

-- object: bancos.banco_seq | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.banco_seq CASCADE;
CREATE SEQUENCE bancos.banco_seq
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.banco_seq OWNER TO bancos;
-- ddl-end --

-- object: bancos.banco | type: TABLE --
-- DROP TABLE IF EXISTS bancos.banco CASCADE;
CREATE TABLE bancos.banco(
	id bigint NOT NULL DEFAULT nextval('bancos.banco_seq'::regclass),
	codigo varchar(20) NOT NULL,
	nombre varchar(100) NOT NULL,
	pais varchar(2) NOT NULL,
	activo bool NOT NULL DEFAULT false,
	CONSTRAINT banco_pk PRIMARY KEY (id),
	CONSTRAINT banco_codigo_uq UNIQUE (codigo)

);
-- ddl-end --
ALTER TABLE bancos.banco OWNER TO bancos;
-- ddl-end --

-- object: bancos.configuracion_seq | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.configuracion_seq CASCADE;
CREATE SEQUENCE bancos.configuracion_seq
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.configuracion_seq OWNER TO bancos;
-- ddl-end --

-- object: idx_banco_pais | type: INDEX --
-- DROP INDEX IF EXISTS bancos.idx_banco_pais CASCADE;
CREATE INDEX idx_banco_pais ON bancos.banco
	USING btree
	(
	  pais ASC NULLS LAST
	);
-- ddl-end --

-- object: idx_banco_activo | type: INDEX --
-- DROP INDEX IF EXISTS bancos.idx_banco_activo CASCADE;
CREATE INDEX idx_banco_activo ON bancos.banco
	USING btree
	(
	  activo ASC NULLS LAST
	);
-- ddl-end --

-- object: bancos.comentario_seq | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.comentario_seq CASCADE;
CREATE SEQUENCE bancos.comentario_seq
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.comentario_seq OWNER TO bancos;
-- ddl-end --

-- object: bancos.comentario | type: TABLE --
-- DROP TABLE IF EXISTS bancos.comentario CASCADE;
CREATE TABLE bancos.comentario(
	id bigint NOT NULL DEFAULT nextval('bancos.comentario_seq'::regclass),
	ip varchar(50) NOT NULL,
	nombre varchar(150) NOT NULL,
	correo varchar(255) NOT NULL,
	comentario text NOT NULL,
	CONSTRAINT comentario_pk PRIMARY KEY (id)

);
-- ddl-end --
ALTER TABLE bancos.comentario OWNER TO bancos;
-- ddl-end --

-- object: bancos.usuario_seq | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.usuario_seq CASCADE;
CREATE SEQUENCE bancos.usuario_seq
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.usuario_seq OWNER TO bancos;
-- ddl-end --

-- object: bancos.usuario | type: TABLE --
-- DROP TABLE IF EXISTS bancos.usuario CASCADE;
CREATE TABLE bancos.usuario(
	id bigint NOT NULL DEFAULT nextval('bancos.usuario_seq'::regclass),
	usuario varchar(50) NOT NULL,
	clave varchar(150) NOT NULL,
	activo bool NOT NULL DEFAULT false,
	CONSTRAINT usuario_pk PRIMARY KEY (id),
	CONSTRAINT usuario_usr_uq UNIQUE (usuario)

);
-- ddl-end --
ALTER TABLE bancos.usuario OWNER TO bancos;
-- ddl-end --

-- object: idx_usuario_activo | type: INDEX --
-- DROP INDEX IF EXISTS bancos.idx_usuario_activo CASCADE;
CREATE INDEX idx_usuario_activo ON bancos.usuario
	USING btree
	(
	  activo ASC NULLS LAST
	);
-- ddl-end --

-- object: bancos.perfil_seq | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.perfil_seq CASCADE;
CREATE SEQUENCE bancos.perfil_seq
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.perfil_seq OWNER TO bancos;
-- ddl-end --

-- object: bancos.perfil | type: TABLE --
-- DROP TABLE IF EXISTS bancos.perfil CASCADE;
CREATE TABLE bancos.perfil(
	id bigint NOT NULL DEFAULT nextval('bancos.perfil_seq'::regclass),
	usuario_id bigint NOT NULL,
	nombres varchar(150) NOT NULL,
	apellidos varchar(150) NOT NULL,
	correo varchar(255) NOT NULL,
	CONSTRAINT perfil_pk PRIMARY KEY (id)

);
-- ddl-end --
ALTER TABLE bancos.perfil OWNER TO bancos;
-- ddl-end --

-- object: usuario_fk | type: CONSTRAINT --
-- ALTER TABLE bancos.perfil DROP CONSTRAINT IF EXISTS usuario_fk CASCADE;
ALTER TABLE bancos.perfil ADD CONSTRAINT usuario_fk FOREIGN KEY (usuario_id)
REFERENCES bancos.usuario (id) MATCH FULL
ON DELETE RESTRICT ON UPDATE CASCADE;
-- ddl-end --

-- object: perfil_uq | type: CONSTRAINT --
-- ALTER TABLE bancos.perfil DROP CONSTRAINT IF EXISTS perfil_uq CASCADE;
ALTER TABLE bancos.perfil ADD CONSTRAINT perfil_uq UNIQUE (usuario_id);
-- ddl-end --

-- object: bancos.usuario_banco_seq | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.usuario_banco_seq CASCADE;
CREATE SEQUENCE bancos.usuario_banco_seq
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.usuario_banco_seq OWNER TO bancos;
-- ddl-end --

-- object: bancos.usuario_banco | type: TABLE --
-- DROP TABLE IF EXISTS bancos.usuario_banco CASCADE;
CREATE TABLE bancos.usuario_banco(
	id bigint NOT NULL DEFAULT nextval('bancos.usuario_banco_seq'::regclass),
	banco_id bigint NOT NULL,
	usuario_id bigint NOT NULL,
	autorizacion varchar(150) NOT NULL,
	CONSTRAINT usuario_banco_pk PRIMARY KEY (id)

);
-- ddl-end --
ALTER TABLE bancos.usuario_banco OWNER TO bancos;
-- ddl-end --

-- object: banco_fk | type: CONSTRAINT --
-- ALTER TABLE bancos.usuario_banco DROP CONSTRAINT IF EXISTS banco_fk CASCADE;
ALTER TABLE bancos.usuario_banco ADD CONSTRAINT banco_fk FOREIGN KEY (banco_id)
REFERENCES bancos.banco (id) MATCH FULL
ON DELETE RESTRICT ON UPDATE CASCADE;
-- ddl-end --

-- object: usuario_fk | type: CONSTRAINT --
-- ALTER TABLE bancos.usuario_banco DROP CONSTRAINT IF EXISTS usuario_fk CASCADE;
ALTER TABLE bancos.usuario_banco ADD CONSTRAINT usuario_fk FOREIGN KEY (usuario_id)
REFERENCES bancos.usuario (id) MATCH FULL
ON DELETE RESTRICT ON UPDATE CASCADE;
-- ddl-end --

-- object: usuario_banco_uq | type: CONSTRAINT --
-- ALTER TABLE bancos.usuario_banco DROP CONSTRAINT IF EXISTS usuario_banco_uq CASCADE;
ALTER TABLE bancos.usuario_banco ADD CONSTRAINT usuario_banco_uq UNIQUE (banco_id,usuario_id);
-- ddl-end --

-- object: bancos.transaccion_seq | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.transaccion_seq CASCADE;
CREATE SEQUENCE bancos.transaccion_seq
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.transaccion_seq OWNER TO bancos;
-- ddl-end --

-- object: bancos.transaccion | type: TABLE --
-- DROP TABLE IF EXISTS bancos.transaccion CASCADE;
CREATE TABLE bancos.transaccion(
	id bigint NOT NULL DEFAULT nextval('bancos.transaccion_seq'::regclass),
	operacion_id bigint NOT NULL,
	usuario_id bigint NOT NULL,
	banco_id bigint NOT NULL,
	fecha timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
	monto double precision,
	descripcion text,
	autorizacion varchar(150) NOT NULL,
	CONSTRAINT transaccion_pk PRIMARY KEY (id)

);
-- ddl-end --
ALTER TABLE bancos.transaccion OWNER TO bancos;
-- ddl-end --

-- object: bancos.operacion_id | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS bancos.operacion_id CASCADE;
CREATE SEQUENCE bancos.operacion_id
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE bancos.operacion_id OWNER TO bancos;
-- ddl-end --

-- object: bancos.operacion | type: TABLE --
-- DROP TABLE IF EXISTS bancos.operacion CASCADE;
CREATE TABLE bancos.operacion(
	id bigint NOT NULL DEFAULT nextval('bancos.operacion_id'::regclass),
	nombre varchar(150) NOT NULL,
	descripcion varchar(255),
	CONSTRAINT operacion_pk PRIMARY KEY (id)

);
-- ddl-end --
ALTER TABLE bancos.operacion OWNER TO bancos;
-- ddl-end --

-- object: operacion_fk | type: CONSTRAINT --
-- ALTER TABLE bancos.transaccion DROP CONSTRAINT IF EXISTS operacion_fk CASCADE;
ALTER TABLE bancos.transaccion ADD CONSTRAINT operacion_fk FOREIGN KEY (operacion_id)
REFERENCES bancos.operacion (id) MATCH FULL
ON DELETE RESTRICT ON UPDATE CASCADE;
-- ddl-end --

-- object: usuario_fk | type: CONSTRAINT --
-- ALTER TABLE bancos.transaccion DROP CONSTRAINT IF EXISTS usuario_fk CASCADE;
ALTER TABLE bancos.transaccion ADD CONSTRAINT usuario_fk FOREIGN KEY (usuario_id)
REFERENCES bancos.usuario (id) MATCH FULL
ON DELETE RESTRICT ON UPDATE CASCADE;
-- ddl-end --

-- object: banco_fk | type: CONSTRAINT --
-- ALTER TABLE bancos.transaccion DROP CONSTRAINT IF EXISTS banco_fk CASCADE;
ALTER TABLE bancos.transaccion ADD CONSTRAINT banco_fk FOREIGN KEY (banco_id)
REFERENCES bancos.banco (id) MATCH FULL
ON DELETE RESTRICT ON UPDATE CASCADE;
-- ddl-end --


