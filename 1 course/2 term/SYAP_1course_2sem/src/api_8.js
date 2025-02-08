export const getComments = async () => {
     return [
          {
               id: "1",
               body: "Первый комментарий",
               username: "Арсений",
               userId: "1",
               parentId: null,
               createdAt: Date(),
          },
          {
               id: "2",
               body: "Второй комментарий",
               username: "Владислав",
               userId: "2",
               parentId: null,
               createdAt: Date(),
          },
          {
               id: "3",
               body: "Третий комментарий",
               username: "Александра",
               userId: "2",
               parentId: "1",
               createdAt: Date(),
          },
          {
               id: "4",
               body: "Четвертый комментарий",
               username: "Алексей",
               userId: "2",
               parentId: "2",
               createdAt: Date(),
          },
     ];
};

export const createComment = async (text, parentId = null) => {
     // ассинхронная функция
     return {
          id: Math.random().toString(36).substr(2, 9),
          body: text,
          parentId,
          userId: "1",
          username: "Евгений",
          createdAt: new Date().toISOString(),
     };
};

export const updateComment = async (text) => {
     return { text };
};

export const deleteComment = async () => {
     return {};
};
