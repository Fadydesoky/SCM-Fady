CREATE DATABASE AdventureSW
ON PRIMARY (
    NAME = AdventureSW_data,    -- Logical name for the data file
    FILENAME = 'D:\Databases\AdventureSW.mdf',  -- Path for the .mdf file
    SIZE = 10MB,                    -- Initial size of the database file
    MAXSIZE = 100MB,                -- Maximum size the file can grow
    FILEGROWTH = 5MB                -- How much the file will grow each time
)
LOG ON (
    NAME = AdventureSW_log,     -- Logical name for the log file
    FILENAME = 'D:\Databases\AdventureSW_log.ldf', -- Path for the .ldf file
    SIZE = 5MB,                     -- Initial size of the log file
    MAXSIZE = 25MB,                 -- Maximum size the log file can grow
    FILEGROWTH = 5MB                -- How much the log file will grow each time
);
