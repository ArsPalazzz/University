#include "myQueue.h"
#include <iostream>
using namespace std;

void create(Queue** begin, Queue** end, int p, int* cursize, int* size) //������������ ��������� �������
{
    if (*cursize == *size) { printf("������� ������"); return; };
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

void view(Queue* begin) //����� ��������� ������� 
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

void fromFIFO(Queue** begin, Queue** end)      //���������� �������� 
{
    Queue* q;
    q = new Queue;
    if (begin == NULL)     // ������� �����
        q = *begin;                        // ���������� ������� ��������
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
        if (count == 1) { printf("� ������� %d �������\n", count); }
        else if (count > 1 && count < 5) { printf("� ������� %d ��������\n", count); }
        else { printf("� ������� %d ���������\n", count); }
    }
}

void delFirOtr(Queue** begin, Queue** end) {
    Queue* q;
    if (begin == NULL) {    // ������� �����
        printf("������ ������\n");
        return;
    }
    else {
        q = new Queue;
        Queue* temp, * previous, * current;
        if ((*begin)->info < 0) {
            temp = *begin;
            *begin = (*begin)->next;
            delete temp;
            printf("������ ������������� ����� �������!\n");
            return;
        }
        else {
            previous = *begin;
            current = (*begin)->next;

            while (current != NULL && ((current->info) > 0))
            {
                previous = current;
                current = current->next; // ������� � ���������� 
            }
            if (current != NULL)
            {
                temp = current;
                previous->next = current->next;
                delete temp;
                printf("������ ������������� ����� �������!\n");
            }
            else {
                printf("������������� ����� ���\n");
            }
        }
    }
}

void del3Fir(Queue** begin, Queue** end) {
    for (int i = 0; i < 3; i++) {
        fromFIFO(begin, end);
    }
    printf("������ 3 �������� ���� �������\n");
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
    cout << "���������� ��������� ����� ����������� � ������������: " << k << endl;
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