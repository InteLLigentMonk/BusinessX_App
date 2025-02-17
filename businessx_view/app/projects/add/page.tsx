import AddProjectsForm from "@/components/AddProjectsForm";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

function AddProject() {
  return (
    <Card className="w-full max-w-[960px] overflow-hidden">
      <CardHeader className="bg-secondary">
        <CardTitle>Add New Project</CardTitle>
        <CardDescription>What project would you like to add?</CardDescription>
      </CardHeader>
      <CardContent className="pt-4">
        <AddProjectsForm />
      </CardContent>
    </Card>
  );
}
export default AddProject;
