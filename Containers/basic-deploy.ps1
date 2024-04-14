# create a new webapi project
dotnet new webapi -n ContainerApi

# build the container from the application
docker build -f .\Dockerfile .\ContainerApi\ -t containerapi:latest

# run the container (use -d for detached)
docker run --name containerapi -d -p 9991:8080 containerapi:latest

# curl the forecast API url
curl http://localhost:9991/weatherforecast

# OPTIONALLY, push to a registry
# docker tag containerapi:latest my.registrydomain.tld/containerapi:latest
# docker push my.registrydomain.tld/containerapi:latest

# "clean up, clean up, everybody, everywhere..."
docker stop containerapi
docker rm containerapi