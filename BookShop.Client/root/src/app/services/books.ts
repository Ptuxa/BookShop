export interface BookRequest {
    title: string;
    description: string;
    price: number;
}

export const getAllBooks = async () => {
    const response = await fetch("https://localhost:7270/Books");
    
    return response.json();
}

export const createBook = async (bookRequset: BookRequest) => {
    await fetch("https://localhost:7270/Books", {
        method: "POST",
        headers: {
            "content-type": "application/json",            
        },
        body: JSON.stringify(bookRequset),
    });
}

export const updateBook = async (id: string, bookRequset: BookRequest) => {
    await fetch(`https://localhost:7270/Books/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",            
        },
        body: JSON.stringify(bookRequset),
    });
}

export const deleteBook = async (id: string) => {
    await fetch(`https://localhost:7270/Books/${id}`, {
        method: "DELETE",
    });
}