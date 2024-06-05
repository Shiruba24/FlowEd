using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Specification
{
    // Базовая реализация спецификации, которая задает правила выборки данных из коллекции T.
    public class BaseSpecification<T> : ISpecification<T>
    {
        // Конструктор по умолчанию
        public BaseSpecification() { }

        // Конструктор, принимающий критерий в виде лямбда-выражения
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        // Критерий для фильтрации данных
        public Expression<Func<T, bool>> Criteria { get; }

        // Список включаемых в выборку выражений (например, для загрузки связанных данных)
        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        // Выражение для сортировки по возрастанию
        public Expression<Func<T, object>> Sort { get; private set; }

        // Выражение для сортировки по убыванию
        public Expression<Func<T, object>> SortByDescending { get; private set; }

        // Количество элементов для выборки (пагинация)
        public int Take { get; private set; }

        // Количество элементов, которые нужно пропустить (пагинация)
        public int Skip { get; private set; }

        // Флаг, указывающий, используется ли пагинация
        public bool IsPaging { get; private set; }

        // Метод для добавления выражений включения (например, навигационные свойства)
        protected void IncludeMethod(Expression<Func<T, object>> expression)
        {
            Includes.Add(expression);
        }

        // Метод для установки выражения сортировки по возрастанию
        protected void SortMethod(Expression<Func<T, object>> sortExpression)
        {
            Sort = sortExpression;
        }

        // Метод для установки выражения сортировки по убыванию
        protected void SortByDescendingMethod(Expression<Func<T, object>> sortDescendingExpression)
        {
            SortByDescending = sortDescendingExpression;
        }

        // Метод для применения параметров пагинации
        protected void ApplyPagination(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPaging = true;
        }
    }
}
