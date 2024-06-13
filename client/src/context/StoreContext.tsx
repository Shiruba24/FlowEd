// Импортируем необходимые библиотеки и типы из React
import React, { PropsWithChildren, createContext, useState, useContext } from "react";
// Импортируем тип Basket из моделей
import { Basket } from "../models/basket";

// Определяем интерфейс для значений контекста
interface StoreContextValue {
    basket: Basket | null; // Корзина может быть объектом или null
    setBasket: (basket: Basket) => void; // Функция для установки новой корзины
    removeItem: (courseId: string) => void; // Функция для удаления элемента из корзины по идентификатору курса
}

// Создаем контекст с начальным значением undefined
export const StoreContext = createContext<StoreContextValue | undefined>(undefined);

// Хук для использования контекста
export function useStoreContext() {
    // Получаем значение контекста с помощью useContext
    const context = useContext(StoreContext);
    // Если контекст не определен, выбрасываем ошибку
    if (context === undefined) {
        throw new Error("The Store Context is currently undefine");
    }
    // Возвращаем значение контекста
    return context;
}

// Компонент провайдера контекста
export function StoreProvider({ children }: PropsWithChildren<any>) {
    // Инициализируем состояние корзины с начальным значением null
    const [basket, setBasket] = useState<Basket | null>(null);

    // Функция для удаления элемента из корзины по идентификатору курса
    function removeItem(courseId: string) {
        // Если корзина пуста, выходим из функции
        if (!basket) return;

        // Создаем копию массива элементов корзины
        const items = [...basket.items];

        // Находим индекс элемента с заданным идентификатором курса
        const itemIndex = items.findIndex((i) => i.courseId === courseId);

        // Если элемент найден, удаляем его из массива
        if (itemIndex >= 0) {
            items.splice(itemIndex, 1);
            // Обновляем состояние корзины, создавая новый объект корзины с обновленным массивом элементов
            setBasket((prevState) => {
                return { ...prevState!, items: items };
            });
        }
    }

    // Возвращаем провайдер контекста, передавая в него текущее состояние корзины, функцию установки корзины и функцию удаления элемента
    return (
        <StoreContext.Provider value={{ basket, setBasket, removeItem }}>
            {children} {/* Рендерим дочерние элементы, переданные в компонент провайдера */}
        </StoreContext.Provider>
    );
}
