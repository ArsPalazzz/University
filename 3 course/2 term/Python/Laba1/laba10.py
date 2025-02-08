import sklearn
import mglearn
import matplotlib.pyplot as plt
import numpy as np

from sklearn.datasets import make_blobs
from sklearn.svm import LinearSVC, SVC
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler
from sklearn.datasets import load_breast_cancer

# Генерация данных для примера с линейным SVM
X, y = make_blobs(centers=4, random_state=8)
y = y % 2

# Обучение и визуализация линейного SVM
linear_svm = LinearSVC(max_iter=5000).fit(X, y)
mglearn.discrete_scatter(X[:, 0], X[:, 1], y)
mglearn.plots.plot_2d_separator(linear_svm, X)
plt.xlabel("Признак 0")
plt.ylabel("Признак 1")
plt.show()

# Добавление квадратичного признака и визуализация в 3D
X_new = np.hstack([X, X[:, 1:] ** 2])
figure = plt.figure()
ax = figure.add_subplot(111, projection='3d')
mask = y == 0
ax.scatter(X_new[mask, 0], X_new[mask, 1], X_new[mask, 2], c='b', s=60)
ax.scatter(X_new[~mask, 0], X_new[~mask, 1], X_new[~mask, 2], c='r', marker='^', s=60)
ax.set_xlabel("признак0")
ax.set_ylabel("признак1")
ax.set_zlabel("признак1 ** 2")
plt.show()

# Обучение и визуализация границы решения в 3D для линейного SVM
linear_svm_3d = LinearSVC(max_iter=5000).fit(X_new, y)
coef, intercept = linear_svm_3d.coef_.ravel(), linear_svm_3d.intercept_
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

xx = np.linspace(X_new[:, 0].min() - 2, X_new[:, 0].max() + 2, 50)
yy = np.linspace(X_new[:, 1].min() - 2, X_new[:, 1].max() + 2, 50)
XX, YY = np.meshgrid(xx, yy)
ZZ = (coef[0] * XX + coef[1] * YY + intercept) / -coef[2]

ax.plot_surface(XX, YY, ZZ, rstride=8, cstride=8, alpha=0.3)
ax.scatter(X_new[mask, 0], X_new[mask, 1], X_new[mask, 2], c='b', s=60)
ax.scatter(X_new[~mask, 0], X_new[~mask, 1], X_new[~mask, 2], c='r', marker='^', s=60)

ax.set_xlabel("признак0")
ax.set_ylabel("признак1")
ax.set_zlabel("признак1 ** 2")
plt.show()

# Визуализация границы решения в 2D для нелинейного SVM (ядерный SVM)
X, y = mglearn.tools.make_handcrafted_dataset()
svm = SVC(kernel='rbf', C=10, gamma=0.1).fit(X, y)
mglearn.plots.plot_2d_separator(svm, X, eps=.5)
mglearn.discrete_scatter(X[:, 0], X[:, 1], y)
sv = svm.support_vectors_
sv_labels = svm.dual_coef_.ravel() > 0
mglearn.discrete_scatter(sv[:, 0], sv[:, 1], sv_labels, s=15, markeredgewidth=3)
plt.xlabel("Признак 0")
plt.ylabel("Признак 1")
plt.show()

# Визуализация влияния параметров C и gamma для ядерного SVM
fig, axes = plt.subplots(3, 3, figsize=(15, 10))

for ax, C in zip(axes, [-1, 0, 3]):
    for a, gamma in zip(ax, range(-1, 2)):
        mglearn.plots.plot_svm(log_C=C, log_gamma=gamma, ax=a)

axes[0, 0].legend(["class 0", "class 1", "sv class 0", "sv class 1"], ncol=4, loc=(.9, 1.2))
plt.show()

# Загрузка и подготовка данных Breast Cancer для SVM
cancer = load_breast_cancer()
X_train, X_test, y_train, y_test = train_test_split(cancer.data, cancer.target, random_state=0)

# Обучение SVM на данных Breast Cancer без предварительной нормализации
svc = SVC()
svc.fit(X_train, y_train)
print("Правильность на обучающем наборе без нормализации: {:.2f}".format(svc.score(X_train, y_train)))
print("Правильность на тестовом наборе без нормализации: {:.2f}".format(svc.score(X_test, y_test)))

# Визуализация разброса значений признаков до и после нормализации
plt.plot(X_train.min(axis=0), 'o', label="min")
plt.plot(X_train.max(axis=0), '^', label="max")
plt.legend(loc=4)
plt.xlabel("Индекс признака")
plt.ylabel("Величина признака")
plt.yscale("log")
plt.show()

# Нормализация данных и повторное обучение SVM
scaler = StandardScaler()
X_train_scaled = scaler.fit_transform(X_train)
X_test_scaled = scaler.transform(X_test)

svc = SVC()
svc.fit(X_train_scaled, y_train)
print("Правильность на обучающем наборе с нормализацией: {:.3f}".format(svc.score(X_train_scaled, y_train)))
print("Правильность на тестовом наборе с нормализацией: {:.3f}".format(svc.score(X_test_scaled, y_test)))

# Попытка улучшить результат SVM с настройкой параметров C и gamma
svc = SVC(C=1000)
svc.fit(X_train_scaled, y_train)
print("Правильность на обучающем наборе с настройкой параметров: {:.3f}".format(svc.score(X_train_scaled, y_train)))
print("Правильность на тестовом наборе с настройкой параметров: {:.3f}".format(svc.score(X_test_scaled, y_test)))
