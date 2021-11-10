import Cookies from 'js-cookie'

const axios = require('axios');

export const cookieName = 'Otus.PublicSale.Logged';

export function doLogin(data) {
  return new Promise((resolve) => {
    axios.post('/api/users/sign-in', data)
      .then((result) => {
        Cookies.set(cookieName, result.data, { expires: 7, path: '' })
        resolve({ data: result.data, errors: null });
      })
      .catch((error) => {        
        let errors = null;
        Cookies.remove(cookieName)

        if (error.response.data.errors) {
          errors = [];
          for (const [value] of Object.entries(error.response.data.errors)) {
            errors.push(value[0]);
          }
        }
        else if (error.response.data.message) {
          errors = [error.response.data.message];
        }

        resolve({ data: null, errors: errors });
      })
  });
}

export function doRegister(data) {
  return new Promise((resolve) => {
    axios.post('/api/users/sign-up', data)
      .then((result) => {
        resolve({ data: result.data, errors: null });
      })
      .catch((error) => {
        debugger;
        let errors = null;
        Cookies.remove(cookieName)

        if (error.response.data.errors) {
          errors = [];
          for (const [value] of Object.entries(error.response.data.errors)) {
            errors.push(value[0]);
          }
        }
        else if (error.response.data.message) {
          errors = [error.response.data.message];
        }

        resolve({ data: null, errors: errors });
      })
  });
}