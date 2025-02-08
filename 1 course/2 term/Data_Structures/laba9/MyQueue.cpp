#include "myQueue.h"
#include <iostream>
using namespace std;

void create(Queue** begin, Queue** end, int p, int* cursize, int* size) //Формирование элементов очереди
{
    if (*cursize == *size) { printf("Очередь полная"); return; };
    Queue* t = new Queue;
    t->next = NULL;
    if (*begin == NULL)
        *begin = *end = t;
    else
    {
        t->info = p;
        (*end)->next = t;
        *end = t;
    }
    (*cursize)++;
}

void view(Queue* begin) //Вывод элементов очереди 
{
    Queue* t = begin;
    if (t == NULL)
    {
        cout << "Number is empty\n";
        return;
    }
    else
    {
        while (t != NULL)
        {
            printf("%d  ", t->info);
            t = t->next;
        }
    }
}

void fromFIFO(Queue** begin, Queue** end)      //Извлечение элемента 
{
    Queue* q;
    q = new Queue;
    if (begin == NULL)     // очередь пуста
        q = *begin;                        // исключение первого элемента
    *begin = (*begin)->next;
    if (*begin == NULL) *end = NULL;
    delete q;
}

void kolichInQ(Queue* begin) {
    Queue* t = begin;
    int count = 0;
    if (t == NULL)
    {
        cout << "Number is empty\n";
        return;
    }
    else
    {
        while (t != NULL)
        {
            ++count;
            t = t->next;
        }
        if (count == 1) { printf("В очереди %d элемент\n", count); }
        else if (count > 1 && count < 5) { printf("В очереди %d элемента\n", count); }
        else { printf("В очереди %d элементов\n", count); }
    }
}

void delFirOtr(Queue** begin, Queue** end) {
    Queue* q;
    if (begin == NULL) {    // очередь пуста
        printf("Список пустой\n");
        return;
    }
    else {
        q = new Queue;
        Queue* temp, * previous, * current;
        if ((*begin)->info < 0) {
            temp = *begin;
            *begin = (*begin)->next;
            delete temp;
            printf("Первое отрицательное число удалено!\n");
            return;
        }
        else {
            previous = *begin;
            current = (*begin)->next;

            while (current != NULL && ((current->info) > 0))
            {
                previous = current;
                current = current->next; // перейти к следующему 
            }
            if (current != NULL)
            {
                temp = current;
                previous->next = current->next;
                delete temp;
                printf("Первое отрицательное число удалено!\n");
            }
            else {
                printf("Отрицательных чисел нет\n");
            }
        }
    }
}

void del3Fir(Queue** begin, Queue** end) {
    for (int i = 0; i < 3; i++) {
        fromFIFO(begin, end);
    }
    printf("Первые 3 элемента были удалены\n");
}

Queue* findMax(Queue* begin) {
    Queue* t = begin, * mx;
    int max;
    mx = t;
    if (t == NULL)
    {
        cout << "Number is empty\n";
    }
    else
    {
        max = t->info;
        while (t != NULL)
        {
            if (t->info >= max)
            {
                max = t->info;
                mx = t;
            }
            t = t->next;
        }
        return mx;
    }
}

Queue* findMin(Queue* begin) {
    Queue* t = begin, * mn;
    int min;
    mn = t;
    if (t == NULL)
    {
        cout << "Number is empty\n";
    }
    else
    {
        min = t->info;
        while (t != NULL)
        {
            if (t->info <= min)
            {
                min = t->info;
                mn = t;
            }
            t = t->next;
        }
        return mn;
    }
}

Queue* kolichBMNM(Queue* begin) {
    Queue* myMx, * myMn;
    int k = 0;
    Queue* t;
    myMx = findMax(begin);
    myMn = findMin(begin);
    t = myMn;
    t->info = 0;
    while (t->next != myMx) {
        ++k;
        t = t->next;
    }
    cout << "Количество элементов между минимальным и максимальным: " << k << endl;
    return t;
}

void doFZero(Queue* begin) {
    Queue* t = begin;
    if (t == NULL)
    {
        cout << "Number is empty\n";
        return;
    }
    else
    {
        while (t != NULL)
        {
            printf("%d  ", t->info);
            if (t->info == 0) { return; }
            t = t->next;
        }
    }
}