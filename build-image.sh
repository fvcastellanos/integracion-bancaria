sudo docker rm -f dockerservices_integracion-bancaria_1

sudo docker rmi -f integracion-bancaria:latest

sudo docker build -t integracion-bancaria:latest .

