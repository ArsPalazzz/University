//#include <iostream>
//#include <fstream>
//#include <Windows.h>
//#include <string>
//using namespace std;
//
//struct Actors {
//	char* name = new char[20];
//	char* role = new char[20];
//	char* reward = new char[20];
//	char* workExp = new char[10];
//	char* add = new char[500];
//	int* age = new int[2];
//};
//
//
//void aboutActor(const char* nameOfActor, const char* reward, const char* years, const char* add) {
//	system("cls");
//	printf("\t\t\t\t\t\t\t%s\n\n\n%s\n\nСтаж работы: %s\nНаграды: %s\n", nameOfActor, add, years, reward);
//	system("pause");
//	system("cls");
//}
//
//void show(int* gen, const char* name, const char* description, const char* firstAct, const char* firstRole, const char* firstReward, const char* firstWork, const char* firstAdd, const char* secondAct, const char* secondRole, const char* secondReward, const char* secondWork, const char* secondAdd, int perfBudg, int tickPrice) {
//	system("cls");
//	printf("\t\t\t\t\t\t\t%s\n\n\nОписание:\n", name);
//	printf("%s", description);
//	printf("\n\nАктеры:\n1.%s(%s)\n2.%s(%s)\n\nБюджет спектакля: %d BYN\nСтоимость за билет: %d BYN\n\n", firstAct, firstRole, secondAct, secondRole, perfBudg, tickPrice);
//	printf("Чтобы узнать об актере - введите цифру слева от его имени\nЧтобы выйти введите '0'\n");
//	scanf_s("%d", gen);
//
//	switch (*gen) {
//	case 1:
//		aboutActor(firstAct, firstReward, firstWork, firstAdd);
//		break;
//	case 2:
//		aboutActor(secondAct, secondReward, secondWork, secondAdd);
//		break;
//	default: *gen = 1;
//	}
//	system("cls");
//}
//
//void read() {
//	char myf[25];
//	const char* txt = ".txt";
//	printf("Введите название файла(без расширения): ");
//	gets_s(myf, 25);
//	strcat_s(myf, txt);
//	char nameOfAct[35];
//	char roleOfAct[35];
//	char rewardOfAct[35];
//	char workExpOfAct[30];
//	char addOfAct[530];
//
//	ifstream fin(myf);
//
//	fin.getline(nameOfAct, 35);
//	fin.getline(roleOfAct, 35);
//	fin.getline(rewardOfAct, 35);
//	fin.getline(workExpOfAct, 30);
//	fin.getline(addOfAct, 530);
//
//	cout << nameOfAct << endl;
//	cout << roleOfAct << endl;
//	cout << rewardOfAct << endl;
//	cout << workExpOfAct << endl;
//	cout << addOfAct << endl;
//
//	cout << "Файл был считан";
//	fin.close();
//	cin.get();
//}
//
//void write(Actors myarr) {
//	char myf[25];
//	const char* txt = ".txt";
//	printf("Введите название файла(без расширения): ");
//	gets_s(myf, 25);
//	strcat_s(myf, txt);
//
//	ofstream fout(myf);
//	fout << "Name: " << myarr.name << endl;
//	fout << "Role: " << myarr.role << endl;
//	fout << "Reward: " << myarr.reward << endl;
//	fout << "Work experience: " << myarr.workExp << endl;
//	fout << "Add: " << myarr.add << endl;
//
//	cout << "Данные были записаны в файл";
//	fout.close();
//	cin.get();
//}
//
//void Copy(Actors* (&kydaCopir), Actors* (&otkydaCopir), int n)
//{
//	for (int i = 0; i < n; i++) {
//		kydaCopir[i] = otkydaCopir[i];
//	}
//}
//
//void deleteData(Actors* (&ptrOnArr), int& n) {
//	int _n;
//	cout << "Введите индекс структуры (от 0 до " << n - 1 << "): ";
//	scanf_s("%d", &_n);
//
//	cin.get();
//	if (_n >= 0 && _n < n) {
//		// временный массив
//		Actors* buf = new Actors[n];
//		Copy(buf, ptrOnArr, n);
//		// выделяем новую память
//		--n;
//		ptrOnArr = new Actors[n];
//		int q = 0;
//		// заполняем неудаленные данные
//		for (int i = 0; i <= n; i++) {
//			if (i != _n) {
//				ptrOnArr[q] = buf[i];
//				++q;
//			}
//		}
//		delete[]buf;
//		cout << "Данные удалены!" << endl;
//	}
//	else {
//		cout << "Номер введён неверно!" << endl;
//	}
//	cin.get(); cin.get();
//}
//
//void changeData(Actors* (&ptrOnArr), int& n) {
//	int _n;
//	cout << "Введите номер элемента (от 0 до " << n - 1 << "): ";
//	cin >> _n;
//	cin.get();
//
//	// проверка, что ввели правильное значение
//	if (_n >= 0 && _n < n) {
//		printf("Введите имя и фамилию актера: ");
//		cin.getline(ptrOnArr[_n].name, 35);
//		printf("Введите роль актера: ");
//		cin.getline(ptrOnArr[_n].role, 35);
//		printf("Введите награду актера: ");
//		cin.getline(ptrOnArr[_n].reward, 35);
//		printf("Введите стаж работы актера: ");
//		cin.getline(ptrOnArr[_n].workExp, 35);
//		printf("Дополнительно об актере: ");
//		cin.getline(ptrOnArr[_n].add, 500);
//
//		cout << "Данные изменены!" << endl;
//	}
//
//	else { cout << "Номер введён неверно!" << endl; }
//
//	cin.get();
//}
//
//void acts(Actors myActs[], int all) {
//	system("cls");
//	printf("\t\t\t\t\t\tАктеры\n");
//	for (int i = 0; i < all; i++) {
//		printf("%d.Name: %s\n", i + 1, myActs[i].name);
//		printf("  Role: %s\n", myActs[i].role);
//		printf("  Reward: %s\n", myActs[i].reward);
//		printf("  Work experience: %s\n", myActs[i].workExp);
//		printf("  Add: %s\n", myActs[i].add);
//		printf("  Age: %d\n", *(myActs[i].age));
//	}
//	cin.get();
//}
//
//void sortPoNames(Actors myActs[], int all) {
//	system("cls");
//	printf("\t\t\t\t\tОтсортированные актеры\n");
//	int smallest_id;
//
//	for (int i = 0; i < all; i++) {
//		smallest_id = i;
//		for (int i = 0; i < all; i++) {
//			for (int j = i + 1; j < all; j++) {
//				if (strcmp(myActs[i].name, myActs[j].name) > 0) {
//					//меняем местами элементы
//					swap(myActs[i].name, myActs[j].name);
//					swap(myActs[i].role, myActs[j].role);
//					swap(myActs[i].reward, myActs[j].reward);
//					swap(myActs[i].workExp, myActs[j].workExp);
//					swap(myActs[i].add, myActs[j].add);
//					swap(myActs[i].age, myActs[j].age);
//				}
//			}
//		}
//	}
//
//	printf("Данные отсортированы");
//	cin.get();
//
//}
//
//void sortPoAge(Actors myActs[], int all) {
//	system("cls");
//	printf("\t\t\t\t\tОтсортированные актеры\n");
//	int smallest_id;
//
//	for (int i = 0; i < all; i++) {
//		smallest_id = i;
//		for (int i = 0; i < all; i++) {
//			for (int j = i + 1; j < all; j++) {
//				if ((*(myActs[smallest_id].age)) > (*(myActs[j].age))) {
//					smallest_id = j;
//				}
//			}
//			swap(myActs[smallest_id].name, myActs[i].name);
//			swap(myActs[smallest_id].role, myActs[i].role);
//			swap(myActs[smallest_id].reward, myActs[i].reward);
//			swap(myActs[smallest_id].workExp, myActs[i].workExp);
//			swap(myActs[smallest_id].add, myActs[i].add);
//			swap(myActs[smallest_id].age, myActs[i].age);
//		}
//	}
//
//	printf("Данные отсортированы");
//	cin.get();
//
//}
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	int allActs = 5;
//	Actors* everyAct = new Actors[allActs];
//	int i1, i2;
//
//	for (i1 = 0; i1 < allActs; i1++) {
//		printf("Введите имя и фамилию актера: ");
//		gets_s(everyAct[i1].name, 20);
//		printf("Введите роль актера: ");
//		gets_s(everyAct[i1].role, 20);
//		printf("Введите награду актера: ");
//		gets_s(everyAct[i1].reward, 20);
//		printf("Введите стаж работы актера: ");
//		gets_s(everyAct[i1].workExp, 20);
//		printf("Введите описание актера: ");
//		gets_s(everyAct[i1].add, 500);
//		*(everyAct[i1].age) = rand() % 5 + 15;
//	}
//
//	int gen = 1;
//	int myspec;
//
//	while (gen) {
//		system("cls");
//		printf("\t\t\t\t\tДобро пожаловать, в театр мшк бебры\nВыберите спектакль:\n1.Опасные связи\n2.Братья Карамазовы\n3.Крейцерова соната\n4.Девичник\n5.В омуте\n\n\n\nФункции:\n6)Поиск информации об актере по индексу\n7)Чтение файла\n8)Запись структуры в файл\n9)Выборочное удаление структуры\n10)Удаление всех структур\n11)Изменить данные структуры\n12)Вывод информации о всех актерах\n13)Сортировка актеров по алфавиту\n14)Сортировка по возрасту\n0)Выход\nВвод:");
//		scanf_s("%d", &myspec);
//		switch (myspec) {
//		case 1:
//			show(&gen, "Опасные связи", "Маркиза де Мертей и виконт де Вальмон – бывшие любовники. \nУмные, изощрённые и циничные, они хладнокровно играют судьбами других людей. \nРади минутного удовольствия они разрушат жизнь любого, будь то расчётливая \nматрона, пылкий юноша, искушённая куртизанка, светский щёголь, неопытная девушка… Но судьба непредсказуема. \nИ она может очень жестоко посмеяться над тем, кто считал себя её хозяином…", everyAct[0].name, everyAct[0].role, everyAct[0].reward, everyAct[0].workExp, everyAct[0].add, everyAct[1].name, everyAct[1].role, everyAct[1].reward, everyAct[1].workExp, everyAct[1].add, 20000, 15.0);
//			break;
//		case 2:
//			show(&gen, "Братья Карамазовы", "«Братья Карамазовы» – и детектив, и любовный роман, и философский трактат. В нём невероятным образом сплетаются роковая страсть, холодная ненависть, подлый умысел, философские рассуждения, преступное молчание, нравственные искания, жестокость и жертвенность.Мнимая добродетель оборачивается равнодушием, вожделение – истинной любовью, а безграничная свобода – душевным хаосом.История ярких личностей, мужчин и женщин, жаждущих любви, правды и справедливости.", everyAct[2].name, everyAct[2].role, everyAct[2].reward, everyAct[2].workExp, everyAct[2].add, everyAct[3].name, everyAct[3].role, everyAct[3].reward, everyAct[3].workExp, everyAct[3].add, 20000, 15.0);
//			break;
//		case 3:
//			show(&gen, "Крейцерова соната", "«Муж и жена приняли обязательство жить вместе всю жизнь. Но вдруг поняли, что ненавидят друг друга, желают разойтись и всё-таки живут – тогда это тот страшный ад, от которого спиваются, стреляются, убивают или отравляют друг друга…Я Позднышев.Тот самый, который жену убил… Какие металлы в солнце и звёздах – это узнать можно, а вот то, что обличает наше свинство – это трудно, ужасно трудно… Одно во мне есть – я знаю то, что не все ещё скоро узнают».История одной ошибки ? Одного преступления ? А может, единственного самого бесстрашного поступка ?Спектакль – исповедь, спектакль – зеркало, спектакль – размышление.", everyAct[4].name, everyAct[4].role, everyAct[4].reward, everyAct[4].workExp, everyAct[4].add, everyAct[2].name, everyAct[2].role, everyAct[2].reward, everyAct[2].workExp, everyAct[2].add, 15000, 12.5);
//			break;
//		case 4:
//			show(&gen, "Девичник", "Шесть подруг собираются вместе – шесть молодых, красивых, незамужних женщин! Они давно не виделись, да и повод есть: одна из них беременна и собирается рожать. Изначально вечеринка планировалась как милые дамские посиделки: лёгкий алкоголь, лёгкие закуски, а также воспоминания, поздравления, сплетни и упрёки – всего понемножку. Но что-то пошло не так...Трогательно доверчивые, шокирующе откровенные, вызывающе сексапильные, смешные, занудные, сильные, слабые – женщины на сцене предстанут во всех своих обликах.И, конечно же, в спектакле есть мужчины – ведь все женские проблемы в конечном итоге сводятся к ним!", everyAct[1].name, everyAct[1].role, everyAct[1].reward, everyAct[1].workExp, everyAct[1].add, everyAct[3].name, everyAct[3].role, everyAct[3].reward, everyAct[3].workExp, everyAct[3].add, 13000, 10.5);
//			break;
//		case 5:
//			show(&gen, "В омуте", "Я не хочу жить во снах, но почему там мне лучше? Где моя реальность? Я сплю или существую? Я существую в своих снах. Только там я могу жить той жизнью, которую люблю, жизнью, которая мне нравится – с теми, кто никогда не сможет от меня уйти… Все в моей жизни уходят… И как это назвать?..", everyAct[4].name, everyAct[4].role, everyAct[4].reward, everyAct[4].workExp, everyAct[4].add, everyAct[0].name, everyAct[0].role, everyAct[0].reward, everyAct[0].workExp, everyAct[0].add, 15000, 12.5);
//			break;
//		case 6:
//			system("cls");
//			printf("Введите индекс актера: ");
//			int actforfind;
//			scanf_s("%d", &actforfind);
//
//			printf("Имя и фамилия: %s\n", everyAct[actforfind].name);
//			printf("Роль: %s\n", everyAct[actforfind].role);
//			printf("Награда: %s\n", everyAct[actforfind].reward);
//			printf("Стаж работы: %s\n", everyAct[actforfind].workExp);
//			printf("Описание: %s\n", everyAct[actforfind].add);
//			printf("Возраст: %d", &everyAct[actforfind].age);
//			cin.get(); cin.get();
//			break;
//		case 7:
//			cin.get();
//			read();
//			break;
//		case 8:
//			printf("Введите индекс структуры, которую хотите записать в файл: ");
//			int indForW;
//			scanf_s("%d", &indForW);
//			cin.get();
//			write(everyAct[indForW]);
//			break;
//		case 9:
//			cin.get();
//			deleteData(everyAct, allActs);
//			break;
//		case 10:
//			cin.get();
//			delete[] everyAct;
//			everyAct = new Actors[allActs];
//			printf("Все данные были удалены");
//			cin.get();
//			break;
//		case 11:
//			cin.get();
//			changeData(everyAct, allActs);
//			break;
//		case 12:
//			cin.get();
//			acts(everyAct, allActs);
//			break;
//		case 13:
//			cin.get();
//			sortPoNames(everyAct, allActs);
//			break;
//		case 14:
//			cin.get();
//			sortPoAge(everyAct, allActs);
//			break;
//		case 0:
//			exit(0);
//		}
//	}
//}