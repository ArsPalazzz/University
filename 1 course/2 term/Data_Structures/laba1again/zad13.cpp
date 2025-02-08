//#include <iostream>
//#include <forward_list>
//using namespace std;
//
////Написать программу, в которой нужно удалить все элементы односвязного списка и добавить n новых, с выводом на экран
//
//void main() {
//	forward_list<int>mylist = { 1, 2, 3, 4, 5 };
//
//	mylist.clear();
//
//	int n;
//	scanf_s("%d", &n);
//
//	for (int i = 0; i < n; i++) {
//		mylist.push_front(rand() % 10);
//	}
//
//	for (int k : mylist) {
//		printf("%d\t", k);
//	}
//}