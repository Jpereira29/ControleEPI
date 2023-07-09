const url = "https://localhost:7188/api"
import axios from "axios"

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