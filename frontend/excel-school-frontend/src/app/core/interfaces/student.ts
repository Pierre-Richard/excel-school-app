export interface Student {
  id?: number;
  userId?: number;
  classId: number;
  parentId: number;
  name: string;
  firstname: string;
  studentNumber: number;
  birthDate: Date | string;
}
