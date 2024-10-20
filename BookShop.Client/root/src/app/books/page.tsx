"use client"

import Button from "antd/es/button/button"
import { Books } from "../components/books"
import { useEffect, useState } from "react"
import { BookRequest, createBook, deleteBook, getAllBooks, updateBook } from "../services/books"
import Title from "antd/es/typography/Title"
import { CreateUpdateBook, Mode } from "../components/createUpdateBook"

export default function BooksPage() {
    const defaultValues = {
        title: "",
        description: "",
        price: 1,
    } as Book;

    const [values, setValues] = useState<Book>(defaultValues)

    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [mode, setMode] = useState(Mode.Create);

    const handleCreateBook = async (request: BookRequest) => {
        await createBook(request);
        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    }

    const handleUpdateBook = async (id: string, request: BookRequest) => {
        await updateBook(id, request);
        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    }

    const handleDeleteBook = async (id: string) => {
        await deleteBook(id)
        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    }

    const openCreateModal = () => {
        setIsModalOpen(true);
    }

    const closeModal = () => {
        setValues(defaultValues);
        setIsModalOpen(false);
    }

    const openEditModal = (book: Book) => {
        setMode(Mode.Edit);
        setValues(book);
        setIsModalOpen(true)
    }

    useEffect(() => {
        const getBooks = async() => {
            const books = await getAllBooks();
            setLoading(false);
            setBooks(books); 
        }

        getBooks();
    }, [])

    return (
        <div>
            <Button
                type="primary"
                style={{marginTop: "30px"}}
                size="large" 
                onClick={openCreateModal}
            >Добавить книгу</Button>

            <CreateUpdateBook 
                mode={mode}
                values={values}
                isModalOpen={isModalOpen}
                handleCancel={closeModal}
                handleCreate={handleCreateBook}
                handleUpdate={handleUpdateBook}
            ></CreateUpdateBook>
            
            {loading ? <Title>Loading...</Title> : <Books books={books} handleOpen={openEditModal} handleDelete={handleDeleteBook}/>}
        </div>
    )
}