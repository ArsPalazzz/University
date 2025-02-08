#pragma once

#define MYQUEUE1_EQE  0x0000  // возврат в случае пустоты очереди 

struct Queue {
    int info;
    Queue* next;
};


void create(Queue** begin, Queue** end, int p, int* cursize, int* size);
void view(Queue* begin);
void fromFIFO(Queue** begin, Queue** end);
void kolichInQ(Queue* begin);
void delFirOtr(Queue** begin, Queue** end);
void del3Fir(Queue** begin, Queue** end);
Queue* findMax(Queue* begin);
Queue* findMin(Queue* begin);
Queue* kolichBMNM(Queue* begin);
void doFZero(Queue* begin);