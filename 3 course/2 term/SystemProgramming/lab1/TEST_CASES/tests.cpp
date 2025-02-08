#include "tests.h"
#include <iostream>

using namespace std;

namespace tests
{
    BOOL test1(ht::HtHandle* htHandle)
    {
        // Попытка удалить элемент, который уже удален из таблицы
        ht::Element* element = new ht::Element("deleteDeleted", 14, "deleteDeleted", 14);
        ht::insert(htHandle, element);
        ht::removeOne(htHandle, element);

        // Попытка удалить уже удаленный элемент
        BOOL removeResult = ht::removeOne(htHandle, element);

        if (removeResult == FALSE)
            return TRUE;

        return FALSE;
    }

    BOOL test2(ht::HtHandle* htHandle)
    {
        // Попытка получить элемент, который не существует в таблице
        ht::Element* element = new ht::Element("updateTest", 11, "updateTest", 11);
        ht::insert(htHandle, element);
        ht::removeOne(htHandle, element);

        ht::Element* hte = ht::get(htHandle, new ht::Element("updateTest", 11));

        if (hte == FALSE)
            return TRUE;

        return FALSE;
    }

    BOOL test3(ht::HtHandle* htHandle)
    {
        // Попытка удалить элемент, который не существует в таблице
        ht::Element* element = new ht::Element("removeTest", 11, "removeTest", 11);

        // Попытка удалить несуществующий элемент
        BOOL removeResult = ht::removeOne(htHandle, element);

        if (removeResult == FALSE)
            return TRUE;

        return FALSE;
    }

    BOOL test4(ht::HtHandle* htHandle)
    {
        // Попытка обновить элемент, который не существует в таблице
        ht::Element* element = new ht::Element("updateTest", 11, "updateTest", 11);
        ht::insert(htHandle, element);

        // Попытка обновления несуществующего элемента
        BOOL updateResult = ht::update(htHandle, element, "myNewData", 10);

        if (updateResult == FALSE)
            return TRUE;

        return FALSE;
    }
}