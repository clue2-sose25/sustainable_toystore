FROM node:14 AS build

# Build FE
WORKDIR /app
COPY package.json yarn.lock ./
RUN yarn install
COPY . .
RUN yarn build

# Serve FE
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80