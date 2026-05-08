namespace ConstructionSubmittal_API.Enums
{
    // An Enum is different from a class, although they are still a .cs file
    // Enum is a value type - simply a fixed list of named constants.
    // A Class is a blueprint for an obj, containing data and methods.
    // Enum does not have a 'class' keyword, no properties.
    public enum SubmittalStatus
    {
        Draft,         // GC is still prepping it; Sub can't see/edit yet.  Draft will be default status for a newly created Submittal since it's in the 0 slot..
        Open,          // Ball is in the Subcontractor's court to upload docs.
        UnderReview,   // Sub has submitted; GC/Architect are currently reviewing.
        Approved,      // Final State: Success.
        Closed         // Final State: Rejected/Revise & Resubmit (triggers a new revision).
    }
    // So C# treats the above 'types' as integers. Draft - 0, Open - 1, etc.
}
