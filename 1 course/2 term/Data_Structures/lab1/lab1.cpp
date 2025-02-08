#include <iostream>
#include <conio.h>
using namespace std;

enum typesOfDrugs { hormonalAndReproductive = 1, antibioticsAndAntiseptics, vaccinesAndSera, forEyesAndEars, 
	forSkinAndWool, fromFleasAndTicks, forBonesAndJoints };

enum typesForFirst { RolfClub = 1, Астрафарм, CEVA};

enum typesForSecond { Zoetis = 1, Invesa, Bayer};

enum typesForThird { Бизнесофсет = 1, Intervet, Белйодобром};

enum typesForFourth { Агроветзащита = 1, Ветфарм };

enum typesForFifth { Зоомиколь = 1, VEDA, Фиприст };

enum typesForSixth { Beaphar = 1, KRKA, BIOVETA };

enum typesForSeventh { Polidex = 1, Хелвет };

void tsena() {
	cout << "Купить?\n0 - нет\t1 - да\n";
	bool repr;
	cin >> repr;
	if (repr) {
		cout << "Товар успешно куплен!";
	}
	else {
		cout << "Ладно...\n";
	}
}

int main()
{
	setlocale(LC_ALL, "rus");

	int typeOfDrugs, nameOfDrugs; // номер этажа– выбор пользователя
	int exitOrNot1 = 9, exitOrNot2 = 9; // выйти или нет

	cout << "\t\t\t\t\t\tВетеринарная аптека\n";

	while (exitOrNot1 == 9)
	{
		cout << "\n1)Гормональные и репродуктивные\n2)Антибиотики и антисептики\n3)Вакцины и сыворотки\n";
		cout << "4)Для глаз и ушей\n5)Для кожи и шерсти\n6)От блох и клещей\n7)Для костей и суставов\n";
		cin >> typeOfDrugs;

		switch (typeOfDrugs)
		{
		case(hormonalAndReproductive)://////////////////////////////////////////////////////////////////////////////////
			while (exitOrNot2 == 9) {
				cout << "1.1)Rolf club\n1.2)Астрафарм\n1.3)CEVA\n";
				cin >> nameOfDrugs;
				switch (nameOfDrugs) {
					case (RolfClub):
						cout << "Товар стоит 40.0р\n";
						tsena();
						break;
					case (Астрафарм):
						cout << "Товар стоит 35.0р\n";
						tsena();
						break;
					case (CEVA):
						cout << "Товар стоит 34.0р\n";
						tsena();
						break;
					default: cout << "Ошибка!\n\n";
				}
				cout << "Выйти из этого списка - нажмите 0.\n";
				cout << "Выбрать другой товар из этого списка - нажмите 9: ";
				do
				{
					cin >> exitOrNot2;
				} while (exitOrNot2 != 0 && exitOrNot2 != 9);
				cout << endl;
			}
			break;////////////////////////////////////////////////////////////////////////////////////////////////////////

		case(antibioticsAndAntiseptics):
			while (exitOrNot2 == 9) {
				cout << "2.1)Zoetis\n2.2)Invesa\n2.3)Bayer\n";
				cin >> nameOfDrugs;
				switch (nameOfDrugs) {
				case (Zoetis):
					cout << "Товар стоит 15.0р\n";
					tsena();
					break;
				case (Invesa):
					cout << "Товар стоит 20.0р\n";
					tsena();
					break;
				case(Bayer):
					cout << "Товар стоит 35.0р\n";
					tsena();
					break;
				default: cout << "Ошибка!\n\n";
				}
				cout << "Выйти из этого списка - нажмите 0.\n";
				cout << "Выбрать другой товар из этого списка - нажмите 9: ";
				do
				{
					cin >> exitOrNot2;
				} while (exitOrNot2 != 0 && exitOrNot2 != 9);
				cout << endl;
			}
			break;//////////////////////////////////////////////////////////////////////////////////////////////////////

		case(vaccinesAndSera):
			while (exitOrNot2 == 9) {
				cout << "3.1)Бизнесофсет\n3.2)Intervet\n3.3)Белйодобром\n";
				cin >> nameOfDrugs;
				switch (nameOfDrugs) {
				case (Бизнесофсет):  case (Intervet): case(Белйодобром):
					cout << "Товар успешно куплен\n";
					break;
				default: cout << "Ошибка!\n\n";
				}
				cout << "Выйти из этого списка - нажмите 0.\n";
				cout << "Выбрать другой товар из этого списка - нажмите 9: ";
				do
				{
					cin >> exitOrNot2;
				} while (exitOrNot2 != 0 && exitOrNot2 != 9);
				cout << endl;
			}
			break;////////////////////////////////////////////////////////////////////////////////////////////////////////

		case(forEyesAndEars):
			while (exitOrNot2 == 9) {
				cout << "4.1)Агроветзащита\n4.2)Ветфарм\n";
				cin >> nameOfDrugs;
				switch (nameOfDrugs) {
				case (Агроветзащита): case(Ветфарм):
					cout << "Товар успешно куплен\n";
					break;
				default: cout << "Ошибка!\n\n";
				}
				cout << "Выйти из этого списка - нажмите 0.\n";
				cout << "Выбрать другой товар из этого списка - нажмите 9: ";
				do
				{
					cin >> exitOrNot2;
				} while (exitOrNot2 != 0 && exitOrNot2 != 9);
				cout << endl;
			}
			break;///////////////////////////////////////////////////////////////////////////////////////////////////////////

		case(forSkinAndWool):
			while (exitOrNot2 == 9) {
				cout << "5.1)Зоомиколь\n5.2)VEDA\n5.3)Фиприст\n";
				cin >> nameOfDrugs;
				switch (nameOfDrugs) {
				case (Зоомиколь): case(VEDA): case (Фиприст):
					cout << "Товар успешно куплен\n";
					break;
				default: cout << "Ошибка!\n\n";
				}
				cout << "Выйти из этого списка - нажмите 0.\n";
				cout << "Выбрать другой товар из этого списка - нажмите 9: ";
				do
				{
					cin >> exitOrNot2;
				} while (exitOrNot2 != 0 && exitOrNot2 != 9);
				cout << endl;
			}
			break;//////////////////////////////////////////////////////////////////////////////////////////////////////////////

		case(fromFleasAndTicks):
			while (exitOrNot2 == 9) {
				cout << "6.1)Beaphar\n6.2)KRKA\n6.3)BIOVETA\n";
				cin >> nameOfDrugs;
				switch (nameOfDrugs) {
				case (Beaphar): case(KRKA): case (BIOVETA):
					cout << "Товар успешно куплен\n";
					break;
				default: cout << "Ошибка!\n\n";
				}
				cout << "Выйти из этого списка - нажмите 0.\n";
				cout << "Выбрать другой товар из этого списка - нажмите 9: ";
				do
				{
					cin >> exitOrNot2;
				} while (exitOrNot2 != 0 && exitOrNot2 != 9);
				cout << endl;
			}
			break;////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		case(forBonesAndJoints):
			while (exitOrNot2 == 9) {
				cout << "7.1)Polidex\n7.2)Хелвет\n";
				cin >> nameOfDrugs;
				switch (nameOfDrugs) {
				case (Polidex): case(Хелвет):
					cout << "Товар успешно куплен\n";
					break;
				default: cout << "Ошибка!\n\n";
				}
				cout << "Выйти из этого списка - нажмите 0.\n";
				cout << "Выбрать другой товар из этого списка - нажмите 9: ";
				do
				{
					cin >> exitOrNot2;
				} while (exitOrNot2 != 0 && exitOrNot2 != 9);
				cout << endl;
			}
			break;

		default: cout << "Ошибка!\n\n";
		}

		cout << "Чтобы выйти - нажмите 0.\n";
		cout << "Чтобы выбрать другой товар из этого списка - нажмите 9: ";
		do
		{
			cin >> exitOrNot1;
		} while (exitOrNot1 != 0 && exitOrNot1 != 9);
		exitOrNot2 = 9;
		cout << endl;
	}
	return 0;
}