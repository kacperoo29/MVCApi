FROM node:lts-bullseye

WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH

COPY package.json ./
RUN npm install --global --force --silent yarn
RUN yarn install --silent

COPY . ./

RUN chown -Rh node /app/node_modules
USER node
CMD ["npm", "start", "--inspect"]