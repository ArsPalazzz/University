import "axios";

declare module "axios" {
  export interface AxiosRequestConfig {
    skipGlobalErrorHandler?: boolean; // Добавляем ваше пользовательское свойство
  }
}
