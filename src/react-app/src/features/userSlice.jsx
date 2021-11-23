import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import {
  doLogin,
  doRegister,
  doUpdate,
  cookieName
} from './userAPI';
import Cookies from 'js-cookie'

const initialState = loadInitialState();

function loadInitialState() {
  const cookieLogged = Cookies.getJSON(cookieName);
  if (cookieLogged) {
    return {
      logged: true,
      current: cookieLogged,
      errors: null,
      loading: false,      
    }
  }
  else {
    return {
      logged: false,
      current: null,
      errors: null,
      loading: false,
    }
  }
}

export const loginAsync = createAsyncThunk(
  'user/doLogin',
  async (data) => {
    return await doLogin(data);
  }
);

export const registerAsync = createAsyncThunk(
  'user/doRegister',
  async (data) => {
    let result = await doRegister(data);
    if (result.data !== null)
      result = doLogin({
        username: data.username,
        password: data.password
      });
    return result;
  }
);

export const updateAsync = createAsyncThunk(
  'user/doUpdate',
  async (data, { getState }) => {
    debugger;
    const state = getState();
    return await doUpdate(data, state.user.current.token, state.user.current.id);
  }
);

export const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    logout: (state) => {
      state.logged = false;
      state.errors = null;
    },
    setError: (state, action) => {
      debugger;
      state.errors = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(loginAsync.pending, (state) => {
        state.loading = true;
      })
      .addCase(loginAsync.fulfilled, (state, action) => {
        state.loading = false;
        if (action.payload.data === null) {
          state.logged = false;
          state.current = null;
          state.errors = action.payload.errors;
        }
        else {
          state.logged = true;
          state.current = action.payload.data;
          state.errors = null;
        }
      })
      .addCase(registerAsync.pending, (state) => {
        state.loading = true;
      })
      .addCase(registerAsync.fulfilled, (state, action) => {
        state.loading = false;
        if (action.payload.data === null) {
          state.logged = false;
          state.current = null;
          state.errors = action.payload.errors;
        }
        else {
          state.logged = true;
          state.current = action.payload.data;
          state.errors = null;
        }
      })
      .addCase(updateAsync.pending, (state) => {
        state.loading = true;
      })
      .addCase(updateAsync.fulfilled, (state, action) => {
        state.loading = false;
        if (action.payload.data === null) {        
          state.errors = action.payload.errors;
        }
        else {
          state.current.firstName = action.payload.data.firstName;
          state.current.lastName = action.payload.data.lastName;
          state.current.username = action.payload.data.username;
          state.errors = null;

          Cookies.set(cookieName, state.current, { expires: 7, path: '' })
        }
      })
      ;
  }
});

export const { logout, setError } = userSlice.actions;

export const selectLogged = (state) => state.user.logged;
export const selectJWT = (state) => state.user.current?.token;
export const selectCurrent = (state) => state.user.current;
export const selectErrors = (state) => state.user.errors;
export const selectLoading = (state) => state.user.loading;

export default userSlice.reducer;