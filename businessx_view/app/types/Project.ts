import { Contact } from "./Contact";

export type Project = {
  id: number;
  name: string;
  description: string;
  startDate: Date;
  endDate: Date;
  statusId: number;
  statusName: string;
  customerId: number;
  customerName: string;
  customerContact: Contact;
  employeeId: number;
  employeeFirstName: string;
  employeeLastName: string;
  serviceId: number;
  serviceName: string;
};
