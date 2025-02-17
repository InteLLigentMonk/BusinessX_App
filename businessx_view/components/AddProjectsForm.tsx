"use client";

import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { format, parseISO } from "date-fns";
import { Button, buttonVariants } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Input } from "@/components/ui/input";
import { Textarea } from "./ui/textarea";
import { Popover, PopoverContent, PopoverTrigger } from "./ui/popover";
import { cn } from "@/lib/utils";
import { CalendarIcon } from "lucide-react";
import { useEffect, useState } from "react";
import { useToast } from "@/hooks/use-toast";
import { useRouter } from "next/navigation";
import { projectSchema } from "@/app/schemas/projectSchema";
import DialogBox from "./DialogBox";
import { getAll, getOneById } from "@/app/api/Get";
import { Customer } from "@/app/types/Customer";
import { Employee } from "@/app/types/Employee";
import { Service } from "@/app/types/Service";
import { Status } from "@/app/types/Status";
import AddCustomerForm from "./AddCustomerForm";
import AddServiceForm from "./AddServiceForm";
import AddEmployeeForm from "./AddEmployeeForm";

interface AddProjectsFormProps {
  projectId?: string;
}

function AddProjectsForm({ projectId }: AddProjectsFormProps) {
  const [status, setStatus] = useState<Status[]>([]);
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [services, setServices] = useState<Service[]>([]);
  const [employees, setEmployees] = useState<Employee[]>([]);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [descriptionLength, setDescriptionLength] = useState(0);

  const { toast } = useToast();
  const router = useRouter();

  const form = useForm<z.infer<typeof projectSchema>>({
    resolver: zodResolver(projectSchema),
    defaultValues: {
      name: "",
      description: "",
      startDate: undefined,
      endDate: undefined,
      statusId: "",
      customerId: "",
      contactId: "",
      serviceId: "",
      employeeId: "",
    },
  });

  useEffect(() => {
    if (projectId) {
      getOneById("projects", projectId).then((data) => {
        form.reset({
          name: data.name,
          description: data.description,
          startDate: data.startDate ? parseISO(data.startDate) : undefined,
          endDate: data.endDate ? parseISO(data.endDate) : undefined,
          statusId: data.statusId.toString(),
          customerId: data.customerName,
          contactId: data.customerContact.id.toString(),
          serviceId: data.serviceId.toString(),
          employeeId: data.employeeId.toString(),
        });
      });
    }

    getAll("statuses", setStatus);
    getAll("customers", setCustomers);
    getAll("services", setServices);
    getAll("employees", setEmployees);
  }, [projectId, dialogOpen]);

  function onSubmit(values: z.infer<typeof projectSchema>) {
    const selectedCustomer = customers.find(
      (customer) => customer.name === values.customerId
    );
    console.log("selectedCustomer", selectedCustomer);

    const url = projectId
      ? `https://localhost:7036/api/projects/${projectId}`
      : "https://localhost:7036/api/projects";
    const method = projectId ? "PUT" : "POST";

    fetch(url, {
      method: method,
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Id: projectId,
        ...values,
        contactId: selectedCustomer?.contactId,
      }),
    })
      .then((response) => {
        if (response.ok) {
          toast({
            title: "Success!",
            variant: "success",
            description: `Project ${
              projectId ? "updated" : "created"
            } successfully`,
          });
          router.push("/projects");
        } else {
          toast({
            title: "Error!",
            description: `Failed to ${projectId ? "update" : "create"} project`,
            variant: "destructive",
          });
          console.error(`Failed to ${projectId ? "update" : "create"} project`);
        }
      })
      .catch((error) =>
        console.error(
          `Error ${projectId ? "updating" : "creating"} project:`,
          error
        )
      );
  }

  return (
    <Form {...form}>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          form.handleSubmit(onSubmit)(e);
        }}
        className="grid grid-cols-1 gap-4 md:grid-cols-2"
      >
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem className="md:col-span-2">
              <FormLabel>Project name:</FormLabel>
              <FormControl>
                <Input placeholder="..." {...field} className="md:w-1/2" />
              </FormControl>
              <FormDescription>Name of the project.</FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="startDate"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Start date:</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button
                      variant={"outline"}
                      className={cn(
                        "w-full pl-3 text-left font-normal bg-inherit",
                        !field.value && "text-muted-foreground"
                      )}
                    >
                      {field.value ? (
                        format(field.value, "PPP")
                      ) : (
                        <span>Pick a date</span>
                      )}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="w-auto p-0" align="start">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    onSelect={field.onChange}
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormDescription>
                Set a planned start date for the project.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="endDate"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>End date:</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button
                      variant={"outline"}
                      className={cn(
                        "w-full pl-3 text-left font-normal bg-inherit",
                        !field.value && "text-muted-foreground"
                      )}
                    >
                      {field.value ? (
                        format(field.value, "PPP")
                      ) : (
                        <span>Pick a date</span>
                      )}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="w-auto p-0" align="start">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    onSelect={field.onChange}
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormDescription>
                Set a planned end date for the project.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="customerId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Customer:</FormLabel>
              <div className="flex w-full gap-2 items-center">
                <Select onValueChange={field.onChange} value={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select customer" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent className="w-full">
                    {customers.map((customer) => (
                      <SelectItem key={customer.name} value={customer.name}>
                        {customer.name}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
                <DialogBox
                  title={"Add new customer"}
                  trigger={
                    <span
                      className={buttonVariants({ variant: "default" })}
                      onClick={() => setDialogOpen(true)}
                    >
                      +
                    </span>
                  }
                  onClose={() => setDialogOpen(false)}
                >
                  <AddCustomerForm onFormSubmit={() => setDialogOpen(false)} />
                </DialogBox>
              </div>
              <FormDescription>Select the project customer.</FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="serviceId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Service:</FormLabel>
              <div className="flex w-full gap-2 items-center">
                <Select onValueChange={field.onChange} value={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="What service is required" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {services.map((service) => (
                      <SelectItem
                        key={service.id}
                        value={service.id.toString()}
                      >
                        {service.name}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
                <DialogBox
                  title={"Add new Service"}
                  trigger={
                    <span
                      className={buttonVariants({ variant: "default" })}
                      onClick={() => setDialogOpen(true)}
                    >
                      +
                    </span>
                  }
                  onClose={() => setDialogOpen(false)}
                >
                  <AddServiceForm onFormSubmit={() => setDialogOpen(false)} />
                </DialogBox>
              </div>
              <FormDescription>
                Select the service the project requires.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="employeeId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Project Lead:</FormLabel>
              <div className="flex w-full gap-2 items-center">
                <Select onValueChange={field.onChange} value={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Project Lead" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {employees.map((employee) => (
                      <SelectItem
                        key={employee.id}
                        value={employee.id.toString()}
                      >
                        {employee.firstName} {employee.lastName}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
                <DialogBox
                  title={"Add new Employee"}
                  trigger={
                    <span
                      className={buttonVariants({ variant: "default" })}
                      onClick={() => setDialogOpen(true)}
                    >
                      +
                    </span>
                  }
                  onClose={() => setDialogOpen(false)}
                >
                  <AddEmployeeForm onFormSubmit={() => setDialogOpen(false)} />
                </DialogBox>
              </div>
              <FormDescription>Who is the lead on the project.</FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="statusId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Status</FormLabel>
              <Select onValueChange={field.onChange} value={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Current Status" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {status.map((status) => (
                    <SelectItem key={status.id} value={status.id.toString()}>
                      {status.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormDescription>
                Select the Current Status of the project.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="description"
          render={({ field }) => (
            <FormItem className="md:col-span-2">
              <div className="flex justify-between">
                <FormLabel>Description:</FormLabel>
                <FormDescription>
                  <span
                    className={descriptionLength > 400 ? "text-red-500" : ""}
                  >
                    {descriptionLength}
                  </span>
                  <span>{` / 400`}</span>
                </FormDescription>
              </div>
              <FormControl>
                <Textarea
                  className="h-24"
                  placeholder="Details of the project..."
                  {...field}
                  onChange={(e) => {
                    field.onChange(e);
                    setDescriptionLength(e.target.value.length);
                  }}
                />
              </FormControl>
              <FormDescription>
                Small description of the project.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit" className="md:w-fit">
          Submit
        </Button>
      </form>
    </Form>
  );
}
export default AddProjectsForm;
