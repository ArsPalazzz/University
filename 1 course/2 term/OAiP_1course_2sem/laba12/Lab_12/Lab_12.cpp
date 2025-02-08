#include <iostream>
#include <cstdlib>
#include <vector>
#include <iterator>
#include <string>
#include <fstream>

using namespace std;

class BHeap {
private:
    vector <int> heap;
    int l(int parent) {
        int l = 2 * parent + 1;
        if (l < heap.size())
            return l;
        else
            return -1;
    }
    int r(int parent) {
        int r = 2 * parent + 2;
        if (r < heap.size())
            return r;
        else
            return -1;
    }
    int par(int child) {
        int p = (child - 1) / 2;
        if (child == 0)
            return -1;
        else
            return p;
    }
    void heapifyup(int in) {
        if (in >= 0 && par(in) >= 0 && heap[par(in)] > heap[in]) {
            int temp = heap[in];
            heap[in] = heap[par(in)];
            heap[par(in)] = temp;
            heapifyup(par(in));
        }
    }
    void heapifydown(int in) {
        int child = l(in);
        int child1 = r(in);
        if (child >= 0 && child1 >= 0 && heap[child] > heap[child1]) {
            child = child1;
        }
        if (child > 0 && heap[in] > heap[child]) {
            int t = heap[in];
            heap[in] = heap[child];
            heap[child] = t;
            heapifydown(child);
        }
    }
public:
    BHeap() {}
    void Insert(int ele) {
        heap.push_back(ele);
        heapifyup(heap.size() - 1);
    }
    void DeleteMin() {
        setlocale(0, "");
        if (heap.size() == 0) {
            cout << "Куча пустая" << endl;
            return;
        }
        heap[0] = heap.at(heap.size() - 1);
        heap.pop_back();
        heapifydown(0);
        cout << "Элемент удалён" << endl;
    }
    int ExtractMin() {
        if (heap.size() == 0) {
            return -1;
        }
        else
            return heap.front();
    }
    int ExtractI(int pos) {
        if (heap.size() == 0 || pos > heap.size()) {
            return -1;
        }
        else {
            return heap[pos - 1];
        }
    }
    void showHeap() {
        setlocale(0, "");
        vector <int>::iterator pos = heap.begin();
        cout << "Куча -> ";
        while (pos != heap.end()) {
            cout << *pos << " ";
            pos++;
        }
        cout << endl;
    }
    int GetSumOfHeap() {
        int Sum = 0;
        if (heap.size() == 0) {
            return -1;
        }
        else {
            for (int i = 0; i < heap.size(); i++) {
                Sum += heap[i];
            }
            return Sum;
        }
    }
    int GetNumOfLevels() {
        setlocale(0, "");
        if (heap.size() == 0) {
            cout << "Куча пустая!" << endl;
        }
        else {
            int numberOfLevels = 1;
            int elems = 1;;
            while (elems < heap.size()) {
                numberOfLevels++;
                elems = elems * 2;
            }
            return numberOfLevels;
        }
    }
    int Size() {
        return heap.size();
    };
    int UnionHeaps() {
        setlocale(0, "");
        int s = heap.size();
        int size = 0;
        cout << "Введите размер кучи, которую хотите добавить к нынешней: "; cin >> size;
        int* arr = new int[size];
        int ch = 0;
        cout << "Сгенерировать кучу(0) или ввести вручную(1)?\n"; cin >> ch;
        if (ch)
        {
            system("cls");
            cout << "Ввод\n";
            for (int i = 0; i < size; i++)
            {
                cin >> arr[i];
            }
        }
        else {
            for (int i = 0; i < size; i++)
            { 
                arr[i] = 20 + rand() % 40;
            }
        }
        system("cls");
        for (int i = 0; i < size; i++)
        {
            heap.push_back(arr[i]);
            heapifyup(heap.size() - 1);
        }
        return 0;
    }
};
int main() {
    setlocale(0, "");
    BHeap heap;
    while (true) {
        system("color 4");
        system("cls");
        cout << "1 - Вставить элемент\n";
        cout << "2 - Удалить минимальный элемент\n";
        cout << "3 - Вывести минимальный элемент\n";
        cout << "4 - Вывести кучу\n";
        cout << "5 - Объединение двух куч в одну\n";
        cout << "6 - Вывести n элемент\n";
        cout << "7 - Вывести сумму всех элементов кучи\n";
        cout << "8 - Узнать количество уровней\n";
        cout << "9 - Вывести размер кучи\n";
        cout << "0 - Выход\n";
        int c, e;
        cout << "Ввод: ";
        cin >> c;
        switch (c) {
        case 1:
            system("cls");
            cout << "Введите элемент: ";
            cin >> e;
            heap.Insert(e);
            system("pause");
            break;
        case 2:
            system("cls");
            heap.DeleteMin();
            system("pause");
            break;
        case 3:
            system("cls");
            if (heap.ExtractMin() == -1) {
                cout << "Куча пустая" << endl;
            }
            else
                cout << "Минимальный элемент: " << heap.ExtractMin() << endl;
            system("pause");
            break;
        case 4:
            system("cls");
            cout << "Вывод элементов кучи: ";
            heap.showHeap();
            system("pause");
            break;
        case 5:
            system("cls");

            heap.UnionHeaps();

            system("pause");
            break;
        case 0:
            system("cls");
            exit(1);
        case 6:
        {
            system("cls");
            int pos;
            cout << "Введите позицию элемента: "; cin >> pos;
            cout << "Элемент в позиции " << pos << ": " << heap.ExtractI(pos) << endl;
            system("pause");
            break;
        }
        case 7:
        {
            system("cls");
            cout << "Сумма кучи: " << heap.GetSumOfHeap() << endl;
            system("pause");
            break;
        }
        case 8: {
            system("cls");
            cout << "Количество уровней: " << heap.GetNumOfLevels() << endl;
            system("pause");
            break;
        }
        case 9: {
            system("cls");
            if (heap.ExtractMin() == -1) {
                cout << "Куча пустая" << endl;
            }
            else {
                cout << "Размер кучи равен: " << heap.Size() << endl;
            }
            system("pause");
        }
        default:
            break;
        }
    }
    return 0;
}

