-- Table: public.measures

DROP TABLE IF EXISTS public.measures;

CREATE TABLE IF NOT EXISTS public.measures
(
    date timestamp without time zone NOT NULL,
    sensor_id bigint NOT NULL,
    value double precision,
    min_value double precision,
    max_value double precision,
	measure_type varchar(32),
    CONSTRAINT measures_pkey PRIMARY KEY (date, sensor_id),
    CONSTRAINT sensors_station_id_fkey FOREIGN KEY (sensor_id)
        REFERENCES public.stations (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.measures
    OWNER to postgres;