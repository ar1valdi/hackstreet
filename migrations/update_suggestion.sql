DROP TABLE suggestions;

CREATE TABLE suggestions (
    id UUID primary key,
    latitude float,
    longitude float,
    description varchar(500),
    downgrades varchar(500),
    duration int,
    added_by varchar(50),
    water_improvement float,
    air_improvement float,
    sound_improvement float,
    light_improvement float
)