SERVER='services.agz.vbox:5433'
DB_NAME='config_provider'
DB_USER='config_provider'
DB_PASSWD='config_provider'
CNN_STRING="Server=$SERVER;Database=$DB_NAME;User Id=$DB_USER;Password=$DB_PASSWD;"

./../../dist/evolve-db/3.2.0/windows64/evolve.exe \
    info \
    postgresql \
    -c "$CNN_STRING"