"use client";
import { useEffect, useState } from "react";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "./ui/form";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Input } from "./ui/input";
import { Button } from "./ui/button";
import { getAll } from "@/app/api/Get";
import { useRouter } from "next/navigation";
import { useToast } from "@/hooks/use-toast";

function AddServiceForm({
  serviceId,
  onFormSubmit,
}: {
  serviceId?: string;
  onFormSubmit?: () => void;
}) {
  const [services, setServices] = useState<String[]>([]);

  const { toast } = useToast();
  const router = useRouter();

  const serviceSchema = z.object({
    name: z
      .string()
      .min(2)
      .max(30)
      .nonempty()
      .refine(
        (name) => {
          return !services.includes(name);
        },
        {
          message: "Service name must be unique",
        }
      ),
    price: z.number(),
  });

  const form = useForm<z.infer<typeof serviceSchema>>({
    resolver: zodResolver(serviceSchema),
    defaultValues: {
      name: "",
      price: 0,
    },
  });

  function onSubmit(values: z.infer<typeof serviceSchema>) {
    const url = serviceId
      ? `https://localhost:7036/api/services/${serviceId}`
      : "https://localhost:7036/api/services";
    const method = serviceId ? "PUT" : "POST";

    fetch(url, {
      method: method,
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        ...values,
      }),
    })
      .then((response) => {
        if (response.ok) {
          toast({
            title: "Success!",
            variant: "success",
            description: `Service ${
              serviceId ? "updated" : "created"
            } successfully`,
          });
          if (onFormSubmit) {
            onFormSubmit();
          }
        } else {
          toast({
            title: "Error!",
            description: `Failed to ${serviceId ? "update" : "create"} service`,
            variant: "destructive",
          });
          console.error(`Failed to ${serviceId ? "update" : "create"} service`);
        }
      })
      .catch((error) =>
        console.error(
          `Error ${serviceId ? "updating" : "creating"} service:`,
          error
        )
      );
  }

  useEffect(() => {
    getAll("services", setServices);
  }, []);

  return (
    <Form {...form}>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          e.stopPropagation();
          form.handleSubmit(onSubmit)(e);
        }}
        className="flex flex-col gap-4"
      >
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Service Name:</FormLabel>
              <FormControl>
                <Input placeholder="spaceX?" {...field} />
              </FormControl>
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
export default AddServiceForm;
