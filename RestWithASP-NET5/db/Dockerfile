FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestWithASP-NET5/DB/Migrations/ /home/database/
COPY ./RestWithASP-NET5/DB/DataSet/ /home/database/
COPY ./RestWithASP-NET5/CI/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh