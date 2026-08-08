export interface Student {
  id?: number;
  userId?: number;
  className: string;
  parentId: number;
  name: string;
  firstname: string;
  studentNumber: number;
  birthDate: Date | string;
}
