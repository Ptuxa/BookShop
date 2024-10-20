import Modal from "antd/es/modal/Modal";
import { BookRequest } from "../services/books";
import Input from "antd/es/input/Input";
import { useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";

interface Props {
    mode: Mode;
    values: Book,
    isModalOpen: boolean,
    handleCancel: () => void,
    handleCreate: (request: BookRequest) => void,
    handleUpdate: (id: string, request: BookRequest) => void,
}

export enum Mode {
    Create,
    Edit
}

export const CreateUpdateBook = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [title, setTitle] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [priceStr, setPriceStr] = useState<string>("1");
    const [isPriceCorrect, setIsPriceCorrect] = useState<boolean>(true);

    useEffect(() => {
        setTitle(values.title);
        setDescription(values.description);
        setPriceStr(String(values.price));
    }, [values])

    const handleOnOk = async () => {
        const price = Number(priceStr);
        const boolRequest = { title, description, price };

        mode == Mode.Create
            ? handleCreate(boolRequest)
            : handleUpdate(values.id, boolRequest);
    }

    

    const handleOnChangePrice = async (priceFieldStr: string) => {
        const checkPrice = async (priceStr: string) => {
            Number.isNaN(Number(priceStr)) ? setIsPriceCorrect(false) : setIsPriceCorrect(true);
        }
        
        setPriceStr(priceFieldStr);
        checkPrice(priceFieldStr);
    }



    return (
        <Modal
            title={
                mode === Mode.Create ? "Добавить книгу" : "Редактировать книгу"
            }
            open={isModalOpen}
            onOk={handleOnOk}
            onCancel={handleCancel}
            cancelText={"Отмена"}
        >
            <div className="book__modal">
                <Input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder="Название"
                />
                <TextArea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    placeholder="Описание"
                />
                {isPriceCorrect == true 
                ? <Input
                    value={priceStr}
                    onChange={(e) => handleOnChangePrice(e.target.value)}
                    placeholder="Цена"
                />
                : <Input
                    value={priceStr}
                    status="error"
                    onChange={(e) => handleOnChangePrice(e.target.value)}
                    placeholder="Цена"
                />}

            </div>
        </Modal>
    )
}