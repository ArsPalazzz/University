//#include <iostream>
//#include <math.h>
//
//double dihotomia(double a, double b, double e, double dih, double x) {
//	while (abs(a - b) > 2 * e) {
//		x = (a + b) / 2;
//		if (dih <= 0) {
//			b = x;
//		}
//		else {
//			a = x;
//		}
//	}
//	return x;
//}
//
//void nomerfun(const char* text, double(*fun)(double, double, double, double, double), double a, double b, double c, double dih, double x) {
//	printf("%s\n", text);
//	printf("%f\n", dihotomia(a, b, c, dih, x));
//}
//
//void main() {
//	double a = 2.7, b = 13.8;
//	double e = 0.001;
//	double x = 0;
//	nomerfun("Function1", dihotomia, a, b, e, exp(x) + 2 * pow(x, 2) - 3, x);
//	nomerfun("Function2", dihotomia, a, b, e, pow(x, 3) + 3, x);
//}