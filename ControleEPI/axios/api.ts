const url = "https://localhost:7188/api"
import axios from "axios"
import { Product } from "~/types/Product";

export async function getCategories() {
    try {
        return await axios.get(`${url}/Category`);
    } catch (error) {
        console.error(error);
    }
}

export async function getProductsPerCategory(categoryId: number) {
    try {
        return await axios.get(`${url}/Product/Category/${categoryId}`);
    } catch (error) {
        console.error(error);
    }
}

export async function getProduct(id: number) {
    try {
        return await axios.get(`${url}/Product/${id}`)
    } catch (error) {
        console.log(error)
    }
}

export async function createProduct(data: Product) {
    try {
        return await axios.post(`${url}/Product`, data);
    } catch (error) {
        console.error(error);
    }
}

export async function updateProduct(data: Product) {
    try {
        return await axios.put(`${url}/Product/${data.productId}`, data);
    } catch (error) {
        console.error(error);
    }
}

export async function deleteProduct(id: number) {
    try {
        return await axios.delete(`${url}/Product/${id}`);
    } catch (error) {
        console.error(error);
    }
}