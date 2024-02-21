#! /bin/bash

SERVER='localhost:5432'
DB_NAME='red-cobra'
DB_USER='red-cobra'
DB_PASSWD='!cyHen20'
CNN_STRING="Server=$SERVER;Database=$DB_NAME;User Id=$DB_USER;Password=$DB_PASSWD;"

./../../dist/evolve-db/3.2.0/linux64/evolve \
    info \
    postgresql \
    -c "$CNN_STRING"
