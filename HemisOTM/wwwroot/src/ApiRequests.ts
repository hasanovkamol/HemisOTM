
import axios from "axios"
const instance = axios.create({
    method: "post",
    baseURL: 'https://some-domain.com',
    url: 'api/',
    timeout: 1000,
    headers: { 'X-Custom-Header': 'foobar' },
  // `transformRequest` allows changes to the request data before it is sent to the server
  // This is only applicable for request methods 'PUT', 'POST', 'PATCH' and 'DELETE'
  // The last function in the array must return a string or an instance of Buffer, ArrayBuffer,
  // FormData or Stream
  // You may modify the headers object.
    transformRequest: [function (data, headers) {
        // Do whatever you want to transform the data
        return data;
    }],

    // `transformResponse` allows changes to the response data to be made before
    // it is passed to then/catch
    transformResponse: [function (data) {
        // Do whatever you want to transform the data
        return data;
    }],
    data: {
        firstName: 'Fred'
    },
    auth: {
        username: 'janedoe',
        password: 's00pers3cret'
    },
    responseType: 'json' // default
});
export default {
    async get(url: string) {
        let res = await axios.get(url);
        return res.data;
    },
    async post(url: string, data: any) {
        let res = await axios.post(url, data);
        return res.data;
    },
    async update(url: string, data: any) {
        let res = await axios.put(url, data);
        return res.data;
    },
    async delete(url: string, data: any) {
        let res = await axios.delete(url, data);
        return res.data;
    }
}