docker build --tag 'VueAndApi' .
docker run -p 8080:8080 --entrypoint "/bin/bash" apiweb start.sh -d VueAndApi