# Containerized .NET

One of the biggest benefits of moving to .NET Core is the ability to run your application on multiple hosting platforms, such as Linux and in containerized environments like Docker and Kubernetes due to several key factors:

1. **Cross-Platform Compatibility** - .NET Core is designed to be cross-platform, meaning it can run on various operating systems including Windows, Linux, and macOS. This allows applications developed with .NET Core to be deployed on Linux systems, which was not possible with the traditional .NET Framework.

2. **Containerization Support** - .NET Core applications can be packaged into lightweight, self-contained containers using Docker. Containers encapsulate all the necessary dependencies, libraries, and runtime environments, making them highly portable across different systems. This enables seamless deployment and scaling of applications in containerized environments.

3. **Microservices Architecture** - .NET Core facilitates the development of microservices-based applications, which are inherently well-suited for containerized environments like Kubernetes. Microservices allow applications to be broken down into smaller, independent components that can be deployed and managed separately. Kubernetes provides orchestration and management capabilities for these microservices, enabling efficient scaling, deployment, and monitoring.

4. **Performance and Scalability** - .NET Core offers improved performance and scalability compared to the traditional .NET Framework, making it more suitable for modern cloud-native applications deployed in containerized environments. It is optimized for high throughput and low-latency scenarios, which are essential for applications running in distributed environments like Kubernetes clusters.

## Deploying a Web API to a Container

You can quickly generate a web API project and deploy to a docker container host in a couple lines. *Be sure that Docker is installed on your host*

```shell
# create a new webapi project
dotnet new webapi -n ContainerApi

# build the container from the application
docker build -f .\Dockerfile .\ContainerApi\ -t containerapi:latest

# OPTIONALLY, push to a registry
# docker tag containerapi:latest my.registrydomain.tld/containerapi:latest
# docker push my.registrydomain.tld/containerapi:latest

# run the container (use -d for detached, and on local port 9991)
docker run --name containerapi -d -p 9991:8080 containerapi:latest
```

Once the container image has been built and is running, you can invoke a request to it:

```shell
# curl the forecast API url
curl http://localhost:9991/weatherforecast
```

Finally, remove your test container:

```shell
# "clean up, clean up, everybody, everywhere..."
docker stop containerapi
docker rm containerapi
```