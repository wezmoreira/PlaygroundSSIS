FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

RUN apt-get update && apt-get install -y \
    curl \
    apt-transport-https \
    gnupg \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev \
    && rm -rf /var/lib/apt/lists/*

ENV PATH="$PATH:/opt/mssql-tools/bin"

COPY entrypoint.sh /usr/config/entrypoint.sh
RUN chmod +x /usr/config/entrypoint.sh

ENTRYPOINT ["/usr/config/entrypoint.sh"]