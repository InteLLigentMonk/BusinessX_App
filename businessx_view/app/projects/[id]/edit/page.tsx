"use client";
import { useParams } from "next/navigation";
import AddProjectsForm from "@/components/AddProjectsForm";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

function EditProjectPage() {
  const { id } = useParams();

  return (
    <Card className="w-full max-w-[800px] overflow-hidden">
      <CardHeader className="bg-secondary">
        <CardTitle>Edit project P-{id}</CardTitle>
      </CardHeader>
      <CardContent className="pt-4">
        <AddProjectsForm projectId={id as string} />
      </CardContent>
    </Card>
  );
}
export default EditProjectPage;
