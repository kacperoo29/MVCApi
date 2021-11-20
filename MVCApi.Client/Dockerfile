FROM node:lts-bullseye

WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH

COPY package.json ./
RUN npm install --global --force --silent yarn
RUN yarn install --silent
# RUN npm install react-scripts@4.0.3 -g --silent

COPY . ./

CMD ["npm", "start"]