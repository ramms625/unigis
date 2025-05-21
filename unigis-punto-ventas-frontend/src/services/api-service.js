import axios from 'axios';

const apiUrl = 'https://localhost:7242/api/';


export const getItems = async (endpoint) => {
    const response = await axios.get(apiUrl + endpoint);
    return response.data;
};

export const getItem = async (endpoint) => {
    const response = await axios.get(apiUrl + endpoint);
    return response.data;
}

export const createItem = async (endpoint, item) => {
    const response = await axios.post(apiUrl + endpoint, item);
    return response.data;
};

export const updateItem = async (endpoint, item) => {
    const response = await axios.put(apiUrl + endpoint, item);
    return response.data;
};

export const deleteItem = async (endpoint) => {
    await axios.delete(apiUrl + endpoint);
};