import Cookies from 'js-cookie'

const axios = require('axios');

export const cookieName = 'Otus.PublicSale.Logged';

export function doLogin(data) {
  return new Promise((resolve) => {
    axios.post('/api/users/sign-in', data)
      .then((result) => {
        Cookies.set(cookieName, result.data, { expires: 7, path: '/' })
        resolve({ data: result.data, errors: null });
      })
      .catch((error) => {        
        let errors = [];
        Cookies.remove(cookieName)       

        if (error.response.data.errors) {
          // eslint-disable-next-line
          for (const [key, value] of Object.entries(error.response.data.errors)) {            
            if (Array.isArray(value)) {              
              // eslint-disable-next-line
              value.forEach(element => { errors.push(element); });
            }
            else {
              errors.push(value);
            }
          }
        }
        else if (error.response.data.message) {
          errors = [error.response.data.message];
        }
        else if (error.response.data) {
          errors = [error.response.data];
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
        let errors =  [];
        Cookies.remove(cookieName)

        if (error.response.data.errors) {
          // eslint-disable-next-line
          for (const [key, value] of Object.entries(error.response.data.errors)) {
            if (Array.isArray(value)) {
              // eslint-disable-next-line
              value.forEach(element => { errors.push(element); });
            }
            else {
              errors.push(value);
            }
          }
        }
        else if (error.response.data.message) {
          errors = [error.response.data.message];
        }
        else if (error.response.data) {
          errors = [error.response.data];
        }

        resolve({ data: null, errors: errors });
      })
  });
}

export function doUpdate(data, jwt, id) {
  return new Promise((resolve) => {
    debugger;
    const config = {
      headers: { Authorization: `Bearer ${jwt}` }
    };
    axios.put('/api/users/update/' + id, data, config)
      .then((result) => {
        resolve({ data: data, errors: null });
      })
      .catch((error) => {
        debugger;
        let errors = [];
        if (error.response.data.errors) {
          // eslint-disable-next-line
          for (const [key, value] of Object.entries(error.response.data.errors)) {
            if (Array.isArray(value)) {
              // eslint-disable-next-line
              value.forEach(element => { errors.push(element); });
            }
            else {
              errors.push(value);
            }
          }
        }
        else if (error.response.data.message) {
          errors = [error.response.data.message];
        }
        else if (error.response.data) {
          errors = [error.response.data];
        }

        resolve({ data: null, errors: errors });
      })
  });
}