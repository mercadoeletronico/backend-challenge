FROM azul/zulu-openjdk-alpine:11
MAINTAINER Luiz Maestri <luizricardomaestri@gmail.com>

RUN apk add --no-cache tzdata

ENTRYPOINT exec java $JAVA_OPTS -jar /usr/share/mercado_eletronico/test-backend.jar -Djava.net.preferIPv4Stack=true

# Add the service itself
ADD target/test-backend-*.jar /usr/share/mercado_eletronico/test-backend.jar