docker build -t nicetruck.web .
docker run --name nicetruck.web -d -p 5005:80 nicetruck.web