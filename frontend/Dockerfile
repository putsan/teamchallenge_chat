# Етап 1: Збірка для розробки
FROM node:latest as build-stage

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

# Етап 2: Виробничий етап із використанням nginx
FROM nginx:alpine

# Копіювання зібраних файлів з етапу збірки до директорії nginx
COPY --from=build-stage /app/dist /usr/share/nginx/html

# Ваша команда CMD залежить від того, як ви хочете налаштувати nginx
# Наприклад, можна використовувати дефолтний CMD від nginx, який просто запускає nginx
CMD ["nginx", "-g", "daemon off;"]
