FROM open-liberty:kernel-slim

ARG VERSION=1.0
ARG REVISION=SNAPSHOT

LABEL \
  org.opencontainers.image.authors="Sachith Harshitha Liyanagama" \
  org.opencontainers.image.vendor="Sachi" \
  org.opencontainers.image.url="local" \
  org.opencontainers.image.version="$VERSION" \
  org.opencontainers.image.revision="$REVISION" \
  vendor="Open Liberty" \
  name="rest-api" \
  version="$VERSION-$REVISION" \
  summary="Internal Communication REST API to communicate with the Blockchain" \
  description="This image contains the Internal Communication Rest API microservice running with the Open Liberty runtime."


USER root

COPY --chown=1001:0 \
    src/main/liberty/config \
    /config/

RUN features.sh

COPY --chown=1001:0 \
    target/rest-api.war \
    /config/dropins

USER 1001


RUN configure.sh

# For Spring-Boot project, use the entrypoint below to reduce Tomcat startup time.
#ENTRYPOINT exec java $JAVA_OPTS -Djava.security.egd=file:/dev/./urandom -jar mockapi.jar
